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

namespace CleanArchitecture.Service.Application.TodoLists.Queries.Get
{
    public class GetTodoListQueryHandler :IRequestHandler<GetTodoListQuery,GetTodoListQueryRespons>
    {
        private readonly IBaseRepository repository;

        public GetTodoListQueryHandler(IBaseRepository repository)
        {
            this.repository = repository;
        }
        public async Task<GetTodoListQueryRespons> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
        {
            var Entity = await repository.FindAsync<TodoList>(c => c.ID == request.ID);

            if (!Entity.Any()) throw new ExceptionNotFound(nameof(request), request.ID);

            var EntityOnes = Entity.LastOrDefault();

            var Model = new GetTodoListQueryRespons
            {
                Title = EntityOnes.Title
            };

            return Model;
        }
    }
}
