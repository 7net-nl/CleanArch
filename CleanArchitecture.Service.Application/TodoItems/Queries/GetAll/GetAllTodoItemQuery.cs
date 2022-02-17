using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoItems.Queries.GetAll
{
    public class GetAllTodoItemQuery : IRequest<GetAllTodoItemQueryRespons>
    {
        public GetAllTodoItemQuery()
        {
            CurrentPage = 1;
            CountOnPage = 1;
        }
        public long TodoList_ID { get; set; }
        public short CurrentPage { get; set; }
        public short CountOnPage { get; set; }
    }
}
