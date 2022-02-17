
using CleanArchitecture.Domain.Contract.Exceptions;
using CleanArchitecture.Domain.Contract.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInBasic
{
    public class LogInBasicUserCommandHandler : IRequestHandler<LogInBasicUserCommand,string>
    {
        private readonly IIDentityRepository repository;

        public LogInBasicUserCommandHandler(IIDentityRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(LogInBasicUserCommand request, CancellationToken cancellationToken)
        {
            var Entity = await repository.UserExist(request.Email);

            if (Entity == null) return "Failed";

            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,request.Email),
                new Claim("Password",request.Password)
            };

            var ClaimIdentity = new ClaimsIdentity(Claims, "BasicAthentication");

            await repository.LogOut("BasicAthentication");

            var Result = await repository.LogIn(Entity, request.Password,ClaimIdentity, "BasicAthentication");

            return Result;
        }
    }
}
