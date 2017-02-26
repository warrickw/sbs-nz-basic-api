using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using SbsApiV2.Models;
using Newtonsoft.Json;
using System.Text;

namespace SbsApiV2.Controllers
{
    /// <summary>
    /// Controller for transfering money between personal accounts
    /// </summary>
    [Route("transfer")]
    [SbsAuthorization]
    public class Transfer : Controller
    {
        [HttpPost]
        public async Task<IActionResult> PerformTransfer([FromBody]TransferModel model)
        {
            // Make sure the model is valid
            if (model == null || !ModelState.IsValid || model.Amount > 500)
                return BadRequest(ModelState);

            // Amount: $1.23
            // OR ??    1

            SbsHttpClient httpClient = SbsHttpClient.Create(HttpContext);

            // Create the transfer request
            TransferRequest transferRequest = new TransferRequest();
            transferRequest.FromAccount = model.FromAccount;
            transferRequest.ToAccount = model.ToAccount;
            transferRequest.Amount = (model.Amount / 100.0m).ToString("0.00");
            transferRequest.PaymentType = "PersonalAccountTransfer";
            transferRequest.FromDetails = model.Details;
            transferRequest.sameDesc = model.UseSameDetails;
            transferRequest.ToDetails = new ToDetails { Particulars = model.Particulars ?? "", Code = model.Code ?? "", References = model.Reference ?? "" };
            transferRequest.TransferDate = TimeZoneInfo.ConvertTime(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("UTC"), TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time")).ToString("yyyy-MM-dd");

            // Serialize the post body
            StringContent postBody = new StringContent(HttpContext.GetSbsEncryption().EncryptString(JsonConvert.SerializeObject(transferRequest)), Encoding.UTF8, "application/x-www-form-urlencoded");

            // Run the request
            HttpResponseMessage httpResponse = await httpClient.PostAsync($"https://secure.sbsbank.co.nz/personal/webservices/Bank/customers/byId/{HttpContext.GetAuthorizationToken().UserId}/moveMoney", postBody);
            
            // Validate the response
            if (!httpResponse.IsSuccessStatusCode)
            {
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return Unauthorized();
                else
                    return BadRequest("Error completing transaction");
            }

            // Parse the transfer result response
            TransferResponse response = await httpResponse.Content.ReadAs<TransferResponse>(HttpContext.GetSbsEncryption());

            return Ok(response);
        }
    }
}
