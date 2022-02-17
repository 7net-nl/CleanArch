using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class TodoList : Entity
    {
        public TodoList()
        {
            TodoItems = new List<TodoItem>();
        }
        public string Title { get; set; }
        public List<TodoItem>  TodoItems { get; set; }
    }
}
