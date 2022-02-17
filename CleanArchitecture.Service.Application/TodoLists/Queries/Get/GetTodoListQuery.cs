using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoLists.Queries.Get
{
    public class GetTodoListQuery : IRequest<GetTodoListQueryRespons>
    {
        public long ID { get; set; }
    }
}
