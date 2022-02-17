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

namespace CleanArchitecture.Service.Application.TodoLists.Commands.Update
{
    public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodolistCommand,string>
    {
        private readonly IBaseRepository repository;

        public UpdateTodoListCommandHandler(IBaseRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(UpdateTodolistCommand request, CancellationToken cancellationToken)
        {
            var Entity = await repository.FindAsync<TodoList>(c => c.ID == request.ID);
            if (!Entity.Any()) throw new ExceptionNotFound(nameof(request), request.ID);
            var EntityComplete = Entity.LastOrDefault();
            EntityComplete.Title = request.Title;
            var Result = repository.UpdateAsync(EntityComplete);
            await repository.SaveAsync();


            return await Result;

        }
    }
}
