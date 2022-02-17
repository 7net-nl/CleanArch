using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInApiKey;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInBasic;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInJwt;

namespace CleanArchitecture.UI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ApiController : ControllerBase
    {
        protected IMediator Mediator => HttpContext.RequestServices.GetService<IMediator>();


    }
}
