using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoItems.Commands.Create
{
    public class CreateTodoItemCommand : IRequest<string>
    {
        public string Title { get; set; }
        public long TodoList_ID { get; set; }
    }
}
