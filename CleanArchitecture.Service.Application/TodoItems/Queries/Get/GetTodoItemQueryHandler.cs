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

namespace CleanArchitecture.Service.Application.TodoItems.Queries.Get
{
    public class GetTodoItemQueryHandler : IRequestHandler<GetTodoItemQuery,GetTodoItemQueryRespons>
    {
        private readonly IBaseRepository repository;

        public GetTodoItemQueryHandler(IBaseRepository repository)
        {
            this.repository = repository;
        }
        public async Task<GetTodoItemQueryRespons> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            var Entity = await repository.FindAsync<TodoItem>(c => c.ID == request.ID);
            

            if (!Entity.Any()) throw new ExceptionNotFound(nameof(request), request.ID);

            var EntityOnes = Entity.LastOrDefault();

            var Model = new GetTodoItemQueryRespons
            {
                Title = EntityOnes.Title
            };

            return Model;
        }
    }
}
