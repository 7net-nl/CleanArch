using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.Systems.Seeds
{
    public class TodoListSeedHelper
    {
        private readonly IBaseRepository repository;

        public TodoListSeedHelper(IBaseRepository repository)
        {
            this.repository = repository;
        }
        public async Task Seed()
        {
            await CreateTodoList();
            await CreateTodoItem();
        }
        private async Task CreateTodoList()
        {
           await repository.AddAsync<TodoList>(new TodoList
           {
                Title = "List 01",
                 ID = 1001
           });

           await repository.AddAsync<TodoList>(new TodoList
            {
                Title = "List 02",
                 ID = 1002
            });

            await repository.AddAsync<TodoList>(new TodoList
            {
                Title = "List 03",
                 ID = 1003
            });
            await repository.AddAsync<TodoList>(new TodoList
            {
                Title = "List 04",
                ID = 1004
            });
           await repository.AddAsync<TodoList>(new TodoList
            {
                Title = "List 05",
                ID = 1005
            });

        }

        private async Task CreateTodoItem()
        {
            await repository.AddAsync(new TodoItem
            {
                Title = "List 01",
                TodoList_ID = 1001
            }); ;

            await repository.AddAsync(new TodoItem
            {
                Title = "List 02",
                 TodoList_ID = 1002
            });

            await repository.AddAsync(new TodoItem
            {
                Title = "List 03",
                 TodoList_ID = 1003
            });
            await repository.AddAsync(new TodoItem
            {
                Title = "List 04",
                 TodoList_ID = 1004
            });
           await repository.AddAsync(new TodoItem
            {
                Title = "List 05",
                 TodoList_ID = 1005
            });

        }

    }
}
