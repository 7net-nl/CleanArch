using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoItems.Commands.Update
{
    public class UpdateTodoItemCommand : IRequest<string>
    {
        public long ID { get; set; }
        public string Title { get; set; }
    }
}
