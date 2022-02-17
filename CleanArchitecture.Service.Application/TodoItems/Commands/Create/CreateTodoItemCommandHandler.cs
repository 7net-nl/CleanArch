using CleanArchitecture.Domain.Contract.Exceptions;
using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoItems.Commands.Create
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand,string>
    {
        private readonly IBaseRepository repository;

        public CreateTodoItemCommandHandler(IBaseRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var ChekingTodoListId = await repository.FindAsync<TodoList>(c => c.ID == request.TodoList_ID);
       
            if (!ChekingTodoListId.Any()) throw new ExceptionNotFound(nameof(request), request.TodoList_ID);

            var Entity = new TodoItem
            {
                ID = new Random().Next(10000, 99999),
                Title = request.Title,
                TodoList_ID = request.TodoList_ID

            };

            var Result = await repository.AddAsync(Entity);

            await repository.SaveAsync();

            return Result;
        }
    }
}
