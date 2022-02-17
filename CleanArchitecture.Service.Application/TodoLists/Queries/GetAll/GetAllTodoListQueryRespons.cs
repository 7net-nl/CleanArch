using System.Collections.Generic;

namespace CleanArchitecture.Service.Application.TodoLists.Queries.GetAll
{
    public class GetAllTodoListQueryRespons
    {
        public List<TodoListVM> TodoLists { get; set; }
        public short TotalPage { get; set; }
        public short CountOnPage { get; set; }
        public short CurrentPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}