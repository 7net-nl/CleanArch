using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(c => c).NotEmpty().NotNull();
            RuleFor(c => c.Email).MinimumLength(5).MaximumLength(50).NotNull().NotEmpty();
            RuleFor(c => c.Password).MinimumLength(5).MaximumLength(50).NotEmpty().NotNull();

        }
    }
}
