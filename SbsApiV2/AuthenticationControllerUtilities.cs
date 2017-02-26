using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SbsApiV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2
{
    public static class AuthorizationControllerUtilities
    {
        /// <summary>
        /// Get the sbs encryption
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static SbsEncryption GetSbsEncryption(this HttpContext context)
        {
            object value = null;

            context?.Items.TryGetValue("SbsEncryption", out value);

            return value as SbsEncryption;
        }

        /// <summary>
        /// Get the authorization token container
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static AuthenticationTokenContainer GetAuthorizationToken(this HttpContext context)
        {
            object value = null;

            context?.Items.TryGetValue("AuthenticationTokenContainer", out value);

            return value as AuthenticationTokenContainer;
        }
    }
}
