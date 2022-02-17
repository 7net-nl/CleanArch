using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoLists.Commands.Delete
{
    public class DeleteTodoListCommandValidation : AbstractValidator<DeleteTodoListCommand>
    {
        public DeleteTodoListCommandValidation()
        {
            RuleFor(c => c).NotNull();
            RuleFor(c => c.ID).NotNull().NotEmpty();
        }
    }
}
