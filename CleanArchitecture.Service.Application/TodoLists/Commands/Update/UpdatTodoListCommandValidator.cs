using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoLists.Commands.Update
{
    class UpdatTodoListCommandValidator : AbstractValidator<UpdateTodolistCommand>
    {
        public UpdatTodoListCommandValidator()
        {
            RuleFor(c => c).NotNull();
            RuleFor(c => c.Title).MinimumLength(2).MaximumLength(20);
        }
    }
}
