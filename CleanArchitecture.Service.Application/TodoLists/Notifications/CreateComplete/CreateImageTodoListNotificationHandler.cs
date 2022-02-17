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
    public class CreateImageTodoListNotificationHandler : INotificationHandler<CreateTodolistCompleteNotification>
    {
        private readonly ILogger<CreateImageTodoListNotificationHandler> logger;

        public CreateImageTodoListNotificationHandler(ILogger<CreateImageTodoListNotificationHandler> logger)
        {
            this.logger = logger;
        }
        public async Task Handle(CreateTodolistCompleteNotification notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Add Image TodoList {notification.TodoListId}");

           await Task.FromResult(0);
        }
    }
}
