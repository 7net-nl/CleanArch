using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.Systems.Seeds
{
    public class TodoListSeedCommandHandler : IRequestHandler<TodoListSeedCommand,string>
    {
        private readonly IBaseRepository repository;

        public TodoListSeedCommandHandler(IBaseRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(TodoListSeedCommand request, CancellationToken cancellationToken)
        {
            await new TodoListSeedHelper(repository).Seed();

            return await Task.FromResult("Complete");

        }
    }
}
