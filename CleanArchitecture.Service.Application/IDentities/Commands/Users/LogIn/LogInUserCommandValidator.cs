using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogIn
{
    public class LogInUserCommandValidator : AbstractValidator<LogInUserCommand>
    {
        public LogInUserCommandValidator()
        {
            RuleFor(c => c).NotEmpty().NotNull();
            RuleFor(c => c.Email).MinimumLength(5).MaximumLength(50).NotNull().NotEmpty();
            RuleFor(c => c.Password).MinimumLength(5).MaximumLength(50).NotEmpty().NotNull();

        }
    }
}
