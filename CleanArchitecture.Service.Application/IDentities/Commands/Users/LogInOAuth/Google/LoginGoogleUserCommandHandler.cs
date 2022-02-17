using CleanArchitecture.Domain.Contract.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOAuth.Google
{
    public class LoginGoogleUserCommandHandler : IRequestHandler<LogInGoogleUserCommand,string>
    {
        private readonly IIDentityRepository repository;

        public LoginGoogleUserCommandHandler(IIDentityRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(LogInGoogleUserCommand request, CancellationToken cancellationToken)
        {
            var Result = await repository.ExternalLogin();

            return Result;
           
        }
    }
}
