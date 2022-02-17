using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOAuth.Google;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOpenId;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogOutOAuth.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CleanArchitecture.UI.Api.Controllers
{
    
    public class ExternalController : ApiController
    {

        [HttpGet("LogIn")]
        public async Task<IActionResult> LogIn([FromRoute] LogInOpenIdUserCommand command)
        {

            var Claims = User.Claims.ToList();
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("LogOut")]
        public async Task<IActionResult> LogOut([FromRoute] LogOutOAuthUserCommand command)
        {
          
            return Ok(await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpGet("Google")]
        public async Task<IActionResult> Google()
        {
           
            return Challenge(new AuthenticationProperties
            {
              RedirectUri = Url.Action("Login")
            },GoogleDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        [HttpGet("GitHub")]
        public async Task<IActionResult> GitHub()
        {

            return Challenge(new AuthenticationProperties
            {
                RedirectUri = Url.Action("Login")
            }, "GitHub");
        }

        [AllowAnonymous]
        [HttpGet("Facebook")]
        public async Task<IActionResult> Facebook()
        {

            return Challenge(new AuthenticationProperties
            {
                RedirectUri = Url.Action("Login")
            }, "Facebook");
        }

        [AllowAnonymous]
        [HttpGet("Identity")]
        public async Task<IActionResult> Identity()
        {

            return Challenge(new AuthenticationProperties
            {
                RedirectUri = Url.Action("Login","External")
            }, "oidc");
        }
    }
}
