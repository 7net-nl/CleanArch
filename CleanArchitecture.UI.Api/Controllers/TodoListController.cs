using CleanArchitecture.Infrascture.Common.HangFires;
using CleanArchitecture.Service.Application.TodoLists.Commands.Create;
using CleanArchitecture.Service.Application.TodoLists.Commands.Delete;
using CleanArchitecture.Service.Application.TodoLists.Commands.Update;
using CleanArchitecture.Service.Application.TodoLists.Notifications.CreateComplete;
using CleanArchitecture.Service.Application.TodoLists.Queries.Get;
using CleanArchitecture.Service.Application.TodoLists.Queries.GetAll;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.UI.Api.Controllers
{
   
    public class TodoListController : ApiController
    {
        
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]CreateTodoListCommand command)
        {
            var Result = Mediator.Schedule(command,TimeSpan.FromSeconds(20));
            //await Mediator.Publish(new CreateTodolistCompleteNotification(Result));

            return Ok(Result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(long Id,[FromBody]UpdateTodolistCommand command)
        {
            if (Id != command.ID) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute]DeleteTodoListCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get([FromRoute]GetTodoListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [AllowAnonymous]
        [HttpGet("All/{CurrentPage}/{CountOnPage}")]
        public async Task<IActionResult> All([FromRoute]GetAllTodoListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }


    }
}
