using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoLists.Commands.Create
{
    public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
    {
        public CreateTodoListCommandValidator()
        {
            RuleFor(c => c).NotEmpty().NotNull();
            RuleFor(c => c.Title).MinimumLength(2).MaximumLength(20);

        }
    }
}
