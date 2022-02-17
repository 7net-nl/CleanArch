using CleanArchitecture.Domain.Contract.Exceptions;
using CleanArchitecture.Domain.Contract.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInJwt
{
    public class LoginUserJwtCommandHandler : IRequestHandler<LoginUserJwtCommand,LoginUserJwtCommandRespons>
    {
        private readonly IIDentityRepository repository;

        public LoginUserJwtCommandHandler(IIDentityRepository repository)
        {
            this.repository = repository;
        }
        public async Task<LoginUserJwtCommandRespons> Handle(LoginUserJwtCommand request, CancellationToken cancellationToken)
        {
            var Entity = await repository.UserExist(request.Email);

            if (string.IsNullOrEmpty(Entity.Email)) throw new ExceptionNotFound(nameof(request), request.Email);

            await repository.LogOut();

            var LoginUser = await repository.LogIn(Entity, request.Password);

            var Result = new LoginUserJwtCommandRespons
            {
                Email = request.Email,
                Result = LoginUser,
                Token = new GenerationToken().Genration(Entity)
            };

            return Result;

            

        }
    }
}
