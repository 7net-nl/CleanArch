using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.TodoLists.Queries.Get
{
    public class GetTodoListQueryValidator : AbstractValidator<GetTodoListQuery>
    {
        public GetTodoListQueryValidator()
        {
            RuleFor(c => c).NotNull();
            RuleFor(c => c.ID).NotNull().NotEmpty();
;        }
    }
}
