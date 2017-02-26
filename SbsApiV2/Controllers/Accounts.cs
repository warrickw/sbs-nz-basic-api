using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SbsApiV2.Models;
using SbsApiV2.Models.AccountGet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SbsApiV2.Controllers
{
    /// <summary>
    /// Account routes getting account data
    /// </summary>
    [Route("accounts")]
    [SbsAuthorization]
    public class Accounts : Controller
    {
        /// <summary>
        /// Get your accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Create the sbs context
            SbsHttpClient httpClient = SbsHttpClient.Create(HttpContext);

            // Add the cookie
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", HttpContext.GetAuthorizationToken().CookieHeader);

            HttpResponseMessage accountsResponse = await httpClient.GetAsync($"/personal/webservices/Bank/customers/byId/{HttpContext.GetAuthorizationToken().UserId}/accounts");

            // Validate the response
            if (!accountsResponse.IsSuccessStatusCode)
            {
                if (accountsResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return Unauthorized();
                else
                    return BadRequest("Error fetching accounts");
            }

            AccountResponse accountResponse = await accountsResponse.Content.ReadAs<AccountResponse>(HttpContext.GetSbsEncryption());
            accountsResponse.Dispose();

            return Ok(accountResponse);
        }


        private async Task<AccountGetResponse> GetTransactionChunk(HttpClient httpClient, long accountId, AccountGetRequest chunkParameters)
        {
            //allChunkParameters

            // Create the post content by encrypting the request params
            StringContent postContent = new StringContent(HttpContext.GetSbsEncryption().EncryptString(JsonConvert.SerializeObject(chunkParameters)));
            HttpResponseMessage accountsResponse = await httpClient.PostAsync($"/personal/webservices/Bank/customers/byId/{HttpContext.GetAuthorizationToken().UserId}/accounts/byId/{accountId}", postContent);

            // Validate the response
            if (!accountsResponse.IsSuccessStatusCode)
            {
                return null;
            }

            string responseString = HttpContext.GetSbsEncryption().DecryptString(await accountsResponse.Content.ReadAsStringAsync());
            accountsResponse.Dispose();
            AccountGetResponse accountResponse = JsonConvert.DeserializeObject<AccountGetResponse>(responseString);

            return accountResponse;
        }

        /// <summary>
        /// Get a specific account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute]long id, [FromQuery]DateTime? from, [FromQuery]DateTime? to)
        {
            // Create the sbs context
            SbsHttpClient httpClient = SbsHttpClient.Create(HttpContext);

            // Add the cookie
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", HttpContext.GetAuthorizationToken().CookieHeader);

            // Keep a list of all the transactions
            List<ItemList> transactions = new List<ItemList>();

            // 1 is the initial chunk
            int chunk = 1;
            bool hasMoreTransactions = true;
            List<AllChunkParameter> chunkParameters = new List<AllChunkParameter>();

            while (hasMoreTransactions)
            {
                //allChunkParameters
                AccountGetRequest requestParams = new AccountGetRequest(from ?? (DateTime.UtcNow.AddDays(-7)), to ?? DateTime.UtcNow, chunk, chunkParameters);

                // Get the transactions for this chunk
                AccountGetResponse transacs = await GetTransactionChunk(httpClient, id, requestParams);

                if (transacs == null)
                    return BadRequest("Could not download chunk");

                // Add all the returned transactions to the list of transactions
                transactions.AddRange(transacs.Account.AccountTransactionListResponseDocument.ItemList);

                // Set the flag wether there are still more transactions or not
                hasMoreTransactions = transacs.Account.AccountTransactionListResponseDocument.HasMoreTransactions;
                chunkParameters = transacs.Account.AccountTransactionListResponseDocument.AllChunkParameters;
                chunk++;
            }

            return Ok(transactions);
        }
    }
}
