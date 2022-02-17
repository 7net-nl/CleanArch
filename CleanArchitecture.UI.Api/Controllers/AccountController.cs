using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogIn;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInApiKey;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInBasic;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInJwt;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOAuth.Google;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogOut;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogOutApiKey;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogOutBasic;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogOutOAuth.Google;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.Register;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CleanArchitecture.UI.Api.Controllers
{
    
    public class AccountController : ApiController
    {
        private readonly IBaseRepository repository;

        public AccountController(IBaseRepository repository)
        {
            this.repository = repository;
        }
        [AllowAnonymous]
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromRoute] LogInBasicUserCommand command)
        {
            
            return Ok(await Mediator.Send(command));
        }
         
        [HttpGet("LogOut")]
        public async Task<IActionResult> LogOut([FromRoute] LogOutUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }



    }
}
