using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using SbsApiV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2
{
    /// <summary>
    /// Sbs authorization filter
    /// </summary>
    public class SbsAuthorizationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            StringValues headerValues;
            if(context.HttpContext.Request.Headers.TryGetValue("Authorization", out headerValues))
            {
                string[] value = headerValues.First().Split(' ');

                if(value.Length == 2 && value[0].ToLower() == "token")
                {
                    AuthenticationTokenContainer authContainer = AuthenticationTokenContainer.Parse(value[1]);
                    if (authContainer.HasExpired)
                    {
                        // Session expired
                        context.Result = new StatusCodeResult(401);
                        return;
                    }

                    context.HttpContext.Items["AuthenticationTokenContainer"] = authContainer;
                    context.HttpContext.Items["SbsEncryption"] = authContainer.CreateEncryption();
                    return;
                }
            }


            // Return unauthorized
            context.Result = new StatusCodeResult(401);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }

    /// <summary>
    /// Factory for the sbs authorization filter
    /// </summary>
    public class SbsAuthorizationAttribute : Attribute, IFilterFactory
    {
        // Implement IFilterFactory
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new SbsAuthorizationFilter();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
