using Microsoft.AspNetCore.Mvc;
using SbsApiV2.Models.BingImageOfTheDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SbsApiV2.Controllers
{
    [Route("images")]
    public class ImageOfTheDay : Controller
    {
        /// <summary>
        /// Redirects to the image of the day url
        /// </summary>
        /// <returns></returns>
        [Route("header")]
        [HttpGet]
        public async Task<IActionResult> GetHeader()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1&mkt=en-US");

            // If not succesfull, return 'bad gateway'
            if (!response.IsSuccessStatusCode)
                return StatusCode(503);

            
            BingImageOfTheDay imgeOfTheDay = await response.Content.ReadAs<BingImageOfTheDay>();
            string url = imgeOfTheDay.images.FirstOrDefault().url;

            if(url == null)
                return StatusCode(503);

            return Redirect("http://www.bing.com" + url);
        }


        /// <summary>
        /// Redirects to the image of the day url
        /// </summary>
        /// <returns></returns>
        [Route("header1")]
        [HttpGet]
        public async Task<IActionResult> GetTransactionsHeader()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://www.bing.com/HPImageArchive.aspx?format=js&idx=1&n=1&mkt=en-US");

            // If not succesfull, return 'bad gateway'
            if (!response.IsSuccessStatusCode)
                return StatusCode(503);

            BingImageOfTheDay imgeOfTheDay = await response.Content.ReadAs<BingImageOfTheDay>();
            string url = imgeOfTheDay.images.FirstOrDefault().url;

            if (url == null)
                return StatusCode(503);

            return Redirect("http://www.bing.com" + url);
        }
    }
}
