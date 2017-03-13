using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using SbsApiV2.Models;
using SbsApiV2.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SbsApiV2.Controllers
{
    [Route("profile")]
    [SbsAuthorization]
    public class Profile : Controller
    {
        /// <summary>
        /// Get your account details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Create the sbs context
            SbsHttpClient httpClient = SbsHttpClient.Create(HttpContext);

            // Add the cookie
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", HttpContext.GetAuthorizationToken().CookieHeader);

            
            HttpResponseMessage httpResponse = await httpClient.GetAsync($"/personal/webservices/Bank/customers/byId/{HttpContext.GetAuthorizationToken().UserId}/profile");

            // Validate the response
            if (!httpResponse.IsSuccessStatusCode)
            {
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return Unauthorized();
                else
                    return BadRequest("Error fetching profile");
            }

            ProfileResponse accountResponse = await httpResponse.Content.ReadAs<ProfileResponse>(HttpContext.GetSbsEncryption());
            httpResponse.Dispose();

            return Ok(new ProfileGetViewModel(accountResponse));
        }
    }
}