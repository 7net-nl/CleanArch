using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoItems.Commands.Update
{
    public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
    {
        public UpdateTodoItemCommandValidator()
        {
            RuleFor(c => c).NotNull();
            RuleFor(c => c.ID).NotNull().NotEmpty();
            RuleFor(c => c.Title).MinimumLength(2).MaximumLength(20);
        }
    }
}
