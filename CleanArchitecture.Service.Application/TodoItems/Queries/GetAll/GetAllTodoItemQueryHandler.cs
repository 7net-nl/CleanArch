using AutoMapper;
using CleanArchitecture.Domain.Contract.Exceptions;
using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Service.Application.Common.Paginations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoItems.Queries.GetAll
{
    public class GetAllTodoItemQueryHandler : IRequestHandler<GetAllTodoItemQuery,GetAllTodoItemQueryRespons>
    {
        private readonly IBaseRepository repository;
        private readonly IMapper mapper;

        public GetAllTodoItemQueryHandler(IBaseRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GetAllTodoItemQueryRespons> Handle(GetAllTodoItemQuery request, CancellationToken cancellationToken)
        {
            var Entities = await repository.FindAsync<TodoItem>(c=>c.TodoList_ID == request.TodoList_ID);

            if (!Entities.Any()) throw new ExceptionNotFound(nameof(request), request.TodoList_ID);

            var ModelPagination = Pagination.Set(request.CurrentPage, request.CountOnPage, Entities.Count());

            var EntitiesDto =  mapper.Map<List<TodoItem>,List<TodoItemVM>>(Entities.ToList());

            var Model = new GetAllTodoItemQueryRespons
            {
                 CountOnPage = request.CountOnPage,
                  CurrentPage = request.CurrentPage,
                   HasNextPage = ModelPagination.HasNextPage,
                    HasPreviousPage = ModelPagination.HasPreviousPage,
                     TotalPage = ModelPagination.TotalPage,
                      TodoItems = EntitiesDto
            };

            return Model;
        }
    }
}
