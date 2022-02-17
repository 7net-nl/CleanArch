using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInBasic
{
    public class AutorizeBasicAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

           

            if (context.HttpContext.GetEndpoint()?.Metadata?.GetMetadata<IAllowAnonymous>() == null)

            {

                try
                {

                    var GetHeader = AuthenticationHeaderValue.Parse(context.HttpContext.Request.Headers["Authorization"]);
                    var DecoderAuth = Convert.FromBase64String(GetHeader.Parameter);
                    var UserNameAndPassword = Encoding.UTF8.GetString(DecoderAuth).Split(":");
                    var UserName = context.HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Email).Value;
                    var Password = context.HttpContext.User.FindFirst(c => c.Type == "Password").Value;

                    if (UserName != UserNameAndPassword[0] || Password != UserNameAndPassword[1])
                        context.Result = new ContentResult
                        {
                            Content = "Status Code: 401; Unauthorized",
                            StatusCode = 401
                        };
                }

                catch
                {
                    if (context.HttpContext.Request.Path.Value.IndexOf("Login") <= 0)
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
}
