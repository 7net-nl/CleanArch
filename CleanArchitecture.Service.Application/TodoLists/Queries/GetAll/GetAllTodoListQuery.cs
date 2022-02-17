using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoLists.Queries.GetAll
{
    public class GetAllTodoListQuery : IRequest<GetAllTodoListQueryRespons>
    {
        public short CurrentPage { get; set; }
        public short CountOnPage { get; set; }
    }
}
