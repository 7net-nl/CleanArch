using AutoMapper;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoLists.Queries.GetAll
{
    public class GetAllTodoListQueryProfile : Profile
    {
        public GetAllTodoListQueryProfile()
        {
            CreateMap<TodoList, TodoListVM>().ReverseMap();
        }
    }
}
