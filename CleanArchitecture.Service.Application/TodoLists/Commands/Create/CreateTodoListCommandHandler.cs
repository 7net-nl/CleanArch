using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Service.Application.TodoLists.Notifications.CreateComplete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoLists.Commands.Create
{
    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand,string>
    {
        private readonly IBaseRepository repository;
        

        public CreateTodoListCommandHandler(IBaseRepository repository)
        {
            this.repository = repository;
           
        }
        public async Task<string> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var Entity = new TodoList
            {
                Title = request.Title,
                 ID = new Random().Next(9999)
            };

            var Result = await repository.AddAsync(Entity);
            await repository.SaveAsync();

            return Result;


        }
    }
}
