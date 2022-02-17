using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoItems.Queries.Get
{
    public class GetTodoitemQueryValidator : AbstractValidator<GetTodoItemQuery>
    {
        public GetTodoitemQueryValidator()
        {
            RuleFor(c => c).NotNull();
            RuleFor(c => c.ID).NotNull().NotEmpty();
        }
    }
}
