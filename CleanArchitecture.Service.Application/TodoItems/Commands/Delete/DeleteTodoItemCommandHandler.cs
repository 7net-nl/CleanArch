using CleanArchitecture.Domain.Contract.Exceptions;
using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoItems.Commands.Delete
{
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand,string>
    {
        private readonly IBaseRepository repository;

        public DeleteTodoItemCommandHandler(IBaseRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var Entity = await repository.FindAsync<TodoItem>(c => c.ID == request.ID);

            if (!Entity.Any()) throw new ExceptionNotFound(nameof(request), request.ID);

            var Result = await repository.DeleteAsync(Entity.LastOrDefault());

            await repository.SaveAsync();

            return Result;

        }
    }
}
