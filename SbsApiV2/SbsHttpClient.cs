using Microsoft.AspNetCore.Http;
using SbsApiV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SbsApiV2
{
    /// <summary>
    /// HttpClient for sbs api calls
    /// </summary>
    public class SbsHttpClient : HttpClient
    {
        private HttpClientHandler handler;

        private SbsHttpClient(HttpClientHandler handler) : base(handler)
        {
            this.handler = handler;


            BaseAddress = new Uri("https://secure.sbsbank.co.nz");
            Timeout = TimeSpan.FromSeconds(10);
        }

        /// <summary>
        /// Create a new instance of the sbs http client
        /// </summary>
        /// <returns></returns>
        public static SbsHttpClient Create(HttpContext httpContext)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            handler.UseCookies = true;

            SbsHttpClient client = new SbsHttpClient(handler);

            // If a token was provided, add it
            if(httpContext.GetAuthorizationToken() != null)
                client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", httpContext.GetAuthorizationToken().CookieHeader);

            return client;
        }

        /// <summary>
        /// Get a cookie :)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetCookieHeader()
        {
            IEnumerable<Cookie> cookies = handler.CookieContainer.GetCookies(new Uri("https://secure.sbsbank.co.nz")).Cast<Cookie>();

            string cookieString = "";

            foreach (var cookie in cookies)
            {
                if (cookieString != "")
                    cookieString += "; ";
                cookieString += cookie.Name + "=" + cookie.Value;
            }

            return cookieString;
        }
    }
}
