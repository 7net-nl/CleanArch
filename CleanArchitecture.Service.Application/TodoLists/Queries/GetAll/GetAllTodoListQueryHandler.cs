using AutoMapper;
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

namespace CleanArchitecture.Service.Application.TodoLists.Queries.GetAll
{
    public class GetAllTodoListQueryHandler : IRequestHandler<GetAllTodoListQuery,GetAllTodoListQueryRespons>
    {
        private readonly IBaseRepository repository;
        private readonly IMapper mapper;

        public GetAllTodoListQueryHandler(IBaseRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GetAllTodoListQueryRespons> Handle(GetAllTodoListQuery request, CancellationToken cancellationToken)
        {
            var Entities = await repository.GetAllAsync<TodoList>();
            
            if (!Entities.Any()) throw new InvalidOperationException();

            var Count =  Entities.Count();
            var TotalPageSet = Count / (double)request.CountOnPage;
            var TotalPage = (short)Math.Ceiling(TotalPageSet);



            var GetAll = Entities.OrderBy(c=>c.ID).Skip((request.CurrentPage - 1) * request.CountOnPage).Take(request.CountOnPage).ToList();

            var TodoLists = mapper.Map<List<TodoList>, List<TodoListVM>>(GetAll);

            return new GetAllTodoListQueryRespons
            {
                CountOnPage = request.CountOnPage,
                CurrentPage = request.CurrentPage,
                HasNextPage = TotalPage > request.CurrentPage ? true : false,
                HasPreviousPage = request.CurrentPage > 1 ? true : false,
                TotalPage = TotalPage,
                TodoLists = TodoLists
                   
            };

           


            


        }
    }
}
