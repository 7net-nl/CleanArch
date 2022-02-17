using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInApiKey
{
    public class AutorizeApiKeyAttribute : Attribute , IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var TokenHeader = context.HttpContext.Request.Headers["Autorization"].LastOrDefault();
                var Token = context.HttpContext.User.FindFirst(c => c.Type == "Token").Value;
                if (Token != TokenHeader || string.IsNullOrEmpty(Token))
                {
                        
                        context.Result = new ContentResult
                        {
                            Content = "Status Code: 401; Unauthorized",
                            StatusCode = 401
                        };
                }

            }

        }
    }
}
