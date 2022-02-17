using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoLists.Notifications.CreateComplete
{
    public class CreateTodolistCompleteNotification : INotification
    {
        public CreateTodolistCompleteNotification(string TodoListId)
        {
            this.TodoListId = TodoListId;
        }
        public string TodoListId { get; set; }
    }
}
