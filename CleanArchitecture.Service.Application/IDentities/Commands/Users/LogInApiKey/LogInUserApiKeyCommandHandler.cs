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

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInApiKey
{
    public class LogInUserApiKeyCommandHandler : IRequestHandler<LoginUserApiKeyCommand,LogInUserApiCommandRespons>
    {
        private readonly IIDentityRepository repository;

        public LogInUserApiKeyCommandHandler(IIDentityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<LogInUserApiCommandRespons> Handle(LoginUserApiKeyCommand request, CancellationToken cancellationToken)
        {
            var Entity = await repository.UserExist(request.Email);

            if (string.IsNullOrEmpty(Entity.Email)) throw new ExceptionNotFound(nameof(request), request.Email);

          
            var Token = GenerationCustomApiKey.Get();

            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,request.Email),
                new Claim("Token", Token)
            };

            var Identity = new ClaimsIdentity(Claims,CookieAuthenticationDefaults.AuthenticationScheme);

            await repository.LogOut(CookieAuthenticationDefaults.AuthenticationScheme);

            var ResultLogIn = await repository.LogIn(Entity, request.Password,Identity,CookieAuthenticationDefaults.AuthenticationScheme);

            var Result = new LogInUserApiCommandRespons
            {
                Email = request.Email,
                Result = ResultLogIn,
                Token = Token
            };

            if (ResultLogIn == "Success")
            {
                return Result;
            }

            else
            {
                Result.Email = "";
                Result.Result = "";
                Result.Token = "";

                return Result;
            }


        }
    }
}
