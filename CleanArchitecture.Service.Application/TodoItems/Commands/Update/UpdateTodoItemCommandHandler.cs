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

namespace CleanArchitecture.Service.Application.TodoItems.Commands.Update
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand,string>
    {
        private readonly IBaseRepository repository;

        public UpdateTodoItemCommandHandler(IBaseRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var Entity = await repository.FindAsync<TodoItem>(c => c.ID == request.ID);

            if (!Entity.Any()) throw new ExceptionNotFound(nameof(request), request.ID);

            var EntityOnes = Entity.LastOrDefault();
            EntityOnes.Title = request.Title;

            var Result = await repository.UpdateAsync(EntityOnes);

            await repository.SaveAsync();

            return Result;
        
        }
    }
}
