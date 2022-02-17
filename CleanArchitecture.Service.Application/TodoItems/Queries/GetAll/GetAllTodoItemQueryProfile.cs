using AutoMapper;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoItems.Queries.GetAll
{
      public class GetAllTodoItemQueryProfile : Profile
    {
        public GetAllTodoItemQueryProfile()
        {
            CreateMap<TodoItem, TodoItemVM>().ReverseMap();
        }
    }
}
