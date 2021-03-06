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

namespace CleanArchitecture.Service.Application.TodoLists.Commands.Delete
{
    public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand,string>
    {
        private readonly IBaseRepository repository;

        public DeleteTodoListCommandHandler(IBaseRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            var Entity = await repository.FindAsync<TodoList>(c => c.ID == request.ID);
            if (!Entity.Any()) throw new ExceptionNotFound(request.GetType().Name, request.ID);
            var Result = await repository.DeleteAsync(Entity.LastOrDefault());

           await repository.SaveAsync();

            return Result;


        }
    }
}
