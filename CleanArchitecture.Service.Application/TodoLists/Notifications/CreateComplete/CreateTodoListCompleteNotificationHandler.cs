using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoLists.Notifications.CreateComplete
{
    public class CreateCompleteTodoListNotificationHandler : INotificationHandler<CreateTodolistCompleteNotification>
    {
        private readonly ILogger<CreateTodolistCompleteNotification> logger;

        public CreateCompleteTodoListNotificationHandler(ILogger<CreateTodolistCompleteNotification> logger)
        {
            this.logger = logger;
        }
        public async Task Handle(CreateTodolistCompleteNotification notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"The Create TodoList Complete {notification.TodoListId}");

            await Task.FromResult(0);
        }
    }
}
