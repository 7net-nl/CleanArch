using CleanArchitecture.Domain.Contract.Interfaces.EF;
using CleanArchitecture.Domain.Contract.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,string>
    {
        private readonly IIDentityRepository repository;

        public RegisterUserCommandHandler(IIDentityRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            
            var Result = await repository.Register(request.Email, request.Password);

            return Result;
        }
    }
}
