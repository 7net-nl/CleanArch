using CleanArchitecture.Domain.Contract.Exceptions;
using CleanArchitecture.Domain.Contract.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogIn
{
    public class LogInUserCommandHandler : IRequestHandler<LogInUserCommand,LogInUserCommandRespons>
    {
        private readonly IIDentityRepository repository;

        public LogInUserCommandHandler(IIDentityRepository repository)
        {
            this.repository = repository;
        }
        public async Task<LogInUserCommandRespons> Handle(LogInUserCommand request, CancellationToken cancellationToken)
        {
            var Entity = await repository.UserExist(request.Email);

            if (string.IsNullOrEmpty(Entity.Email)) throw new ExceptionUserNotFound(nameof(request), request.Email);

            var Result = await repository.LogIn(Entity,request.Password);

            var Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,Entity.Email)
                };

            var ClaimsIDentity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);

            return new LogInUserCommandRespons
            {
                 Result = Result,
                  ClaimsIdentity = ClaimsIDentity
            };

        }
    }
}
