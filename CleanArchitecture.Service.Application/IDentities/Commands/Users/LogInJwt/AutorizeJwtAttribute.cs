using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInJwt
{
    public class AutorizeJwtAttribute : Attribute , IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var Token = context.HttpContext.Session.GetString("Token");
                if (string.IsNullOrEmpty(Token))
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
