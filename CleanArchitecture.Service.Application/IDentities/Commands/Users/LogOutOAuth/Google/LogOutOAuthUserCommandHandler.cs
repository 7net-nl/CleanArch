using CleanArchitecture.Domain.Contract.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogOutOAuth.Google
{
    public class LogOutOAuthUserCommandHandler : IRequestHandler<LogOutOAuthUserCommand,string>
    {
        private readonly IIDentityRepository repository;

        public LogOutOAuthUserCommandHandler(IIDentityRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(LogOutOAuthUserCommand request, CancellationToken cancellationToken)
        {
            var Result = await repository.LogOut(CookieAuthenticationDefaults.AuthenticationScheme);

            return Result;
        }
    }
}
