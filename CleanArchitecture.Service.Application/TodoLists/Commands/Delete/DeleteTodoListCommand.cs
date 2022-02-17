using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoLists.Commands.Delete
{
    public class DeleteTodoListCommand : IRequest<string>
    {
        public long ID { get; set; }
    }
}
