using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInApiKey
{
    public class LogInUserApiKeyCommandValidator :AbstractValidator<LoginUserApiKeyCommand>
    {
        public LogInUserApiKeyCommandValidator()
        {
            RuleFor(c => c).NotNull().NotEmpty();
            RuleFor(c => c.Email).MinimumLength(2).MaximumLength(20);
            RuleFor(c => c.Password).MinimumLength(2).MaximumLength(20);
        }
    }
}
