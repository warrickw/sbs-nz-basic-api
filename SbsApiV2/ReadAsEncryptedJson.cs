using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SbsApiV2
{
    public static class ReadAsEncryptedJson
    {
        /// <summary>
        /// Read the http content as a json object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static async Task<T> ReadAs<T>(this HttpContent content, SbsEncryption encryption)
        {
            string decryptedResponse = encryption.DecryptString(await content.ReadAsStringAsync());
            return JsonConvert.DeserializeObject<T>(decryptedResponse);
        }
    }
}
