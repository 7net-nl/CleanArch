using CleanArchitecture.Service.Application.Common.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoItems.Queries.GetAll
{
    public class GetAllTodoItemQueryRespons : PaginationViewModel
    {
        public List<TodoItemVM> TodoItems { get; set; }
    }
}
