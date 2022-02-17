using CleanArchitecture.Domain.Contract.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogOutApiKey
{
    public class LogOutUserApiKeyCommandHandler : IRequestHandler<LogOutUserApiKeyCommand,string>
    {
        private readonly IIDentityRepository repository;

        public LogOutUserApiKeyCommandHandler(IIDentityRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(LogOutUserApiKeyCommand request, CancellationToken cancellationToken)
        {
            var Result = await  repository.LogOut(CookieAuthenticationDefaults.AuthenticationScheme);

            return Result;
        }
    }
}
