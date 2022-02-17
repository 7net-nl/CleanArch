using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoItems.Commands.Create
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(c => c).NotNull();
            RuleFor(c => c.Title).MinimumLength(2).MaximumLength(20);
            RuleFor(c => c.TodoList_ID).NotNull().NotEmpty();
        }
    }
}
