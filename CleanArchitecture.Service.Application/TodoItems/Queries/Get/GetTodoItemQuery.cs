using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoItems.Queries.Get
{
    public class GetTodoItemQuery : IRequest<GetTodoItemQueryRespons>
    {
        public long ID { get; set; }
    }
}
