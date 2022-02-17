using System;

namespace CleanArchitecture.Domain.Entities
{
    public class TodoItem : Entity
    {
        public string Title { get; set; }
        public long TodoList_ID { get; set; }
    }
}
