using CleanArchitecture.Service.Application.TodoItems.Commands.Create;
using CleanArchitecture.Service.Application.TodoItems.Commands.Delete;
using CleanArchitecture.Service.Application.TodoItems.Commands.Update;
using CleanArchitecture.Service.Application.TodoItems.Queries.Get;
using CleanArchitecture.Service.Application.TodoItems.Queries.GetAll;
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
 
    public class TodoItemController : ApiController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTodoItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update([FromRoute]long Id,[FromBody]UpdateTodoItemCommand command)
        {
            if (Id != command.ID) return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] long Id, [FromBody]DeleteTodoItemCommand command)
        {
            if (Id != command.ID) return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get([FromRoute]GetTodoItemQuery query)
        {
            
            return Ok(await Mediator.Send(query));
        }

        [AllowAnonymous]
        [HttpGet("All/{TodoList_ID}/{CurrentPage}/{CountOnPage}")]
        public async Task<IActionResult> All([FromRoute]GetAllTodoItemQuery query)
        {
            
            return Ok(await Mediator.Send(query));
        }


    }
}
