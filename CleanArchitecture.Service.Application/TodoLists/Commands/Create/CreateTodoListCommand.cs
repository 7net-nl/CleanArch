using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoLists.Commands.Create
{
    public class CreateTodoListCommand : IRequest<string>
    {
        public string Title { get; set; }
    }
}
