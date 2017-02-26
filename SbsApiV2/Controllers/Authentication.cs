using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SbsApiV2.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;

namespace SbsApiV2.Controllers
{
    /// <summary>
    /// Authentication api routes
    /// </summary>
    [Route("authentication")]
    public class Authentication : Controller
    {
        private SbsHttpClient httpClient;

        public Authentication()
        {
            httpClient = SbsHttpClient.Create(HttpContext);
        }

        /// <summary>
        /// Get the one time login response
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private async Task<OneTimeLoginResponse> GetOneTimeLoginResponse(string username, string deviceId)
        {
            // Create a one time login request and run it
            OneTimeLoginRequest loginRequest = new OneTimeLoginRequest(username, deviceId, "Firefox");

            HttpResponseMessage oneTimeLoginResponse = await httpClient.PostAsync("/personal/webservices/joobMobile/core/oneTimeLoginToken", new JsonContent(loginRequest));

            // If the request wasnt a success, return a bad request
            if (!oneTimeLoginResponse.IsSuccessStatusCode)
            {
                string responseBody = await oneTimeLoginResponse.Content.ReadAsStringAsync();
                return null;
            }
                

            // Get the response model for the one time login request
            OneTimeLoginResponse oneTimeResponse = await oneTimeLoginResponse.Content.ReadAs<OneTimeLoginResponse>();
            oneTimeLoginResponse.Dispose();

            return oneTimeResponse;
        }

        /// <summary>
        /// Create a session
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="deviceId"></param>
        /// <param name="encryption"></param>
        /// <returns></returns>
        private async Task<CreateSessionResponse> CreateSession(string username, string password, string deviceId, SbsEncryption encryption)
        {
            // Create the loginr request document
            LoginRequestModel loginRequestDocument = new LoginRequestModel(username, password);
            // Serialize the login request document to a string
            string loginRequestDocumentString = JsonConvert.SerializeObject(loginRequestDocument);

            DeviceInformation deviceInformation = new DeviceInformation();
            deviceInformation.DeviceId = deviceId;

            CreateSessionRequest createSessionRequest = new CreateSessionRequest(username, encryption.EncryptString(loginRequestDocumentString), deviceInformation);

            HttpResponseMessage createSessionResponse = await httpClient.PostAsync("/personal/webservices/joobMobile/core/sessions", new JsonContent(createSessionRequest));

            if (!createSessionResponse.IsSuccessStatusCode)
                return null;

            // Read the create session response object
            CreateSessionResponse createSessionResponseObject = await createSessionResponse.Content.ReadAs<CreateSessionResponse>(encryption);
            createSessionResponse.Dispose();

            // Add all the cookie values
            createSessionResponseObject.CookieHeader = httpClient.GetCookieHeader();

            return createSessionResponseObject;
        }

        /// <summary>
        /// Log in to the sbs api with a username and password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            // Make sure the model is valid
            if (model == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            // Generate a new unique device id
            string deviceId = Guid.NewGuid().ToString();

            // Get the one time login request document
            OneTimeLoginResponse oneTimeResponse = await GetOneTimeLoginResponse(model.Username, deviceId);

            if (oneTimeResponse == null)
                return BadRequest("Could not initiate login");

            // Get the key strengthening iterations from the one time response
            int keyStrengtheningIterations = oneTimeResponse.KeyStrengtheningIterations;

            // Create the session container
            AuthenticationTokenContainer sessionTokenContainer = new AuthenticationTokenContainer(oneTimeResponse.Token, oneTimeResponse.KeyStrengtheningIterations, model.Username);

            // Construct the sbs encryption helper class with all the correct values
            SbsEncryption encryption = sessionTokenContainer.CreateEncryption();

            CreateSessionResponse createSessionResponse = await CreateSession(model.Username, model.Password, deviceId, encryption);

            if (createSessionResponse == null)
                return BadRequest("Could not create session");

            sessionTokenContainer.ExpiresAt = DateTime.Parse(createSessionResponse.ExpiryTime);
            
            // Add all the cookie values
            sessionTokenContainer.CookieHeader = createSessionResponse.CookieHeader;
            sessionTokenContainer.UserId = createSessionResponse.UserId;

            // Add the authorization header with a custom token
            Response.Headers.Add("Authorization", "Token " + sessionTokenContainer.Serialize());

            return Ok(createSessionResponse);
        }
    }
}
