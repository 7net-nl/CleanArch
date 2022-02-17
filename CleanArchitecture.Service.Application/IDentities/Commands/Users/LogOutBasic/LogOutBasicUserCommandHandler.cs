using CleanArchitecture.Domain.Contract.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogOutBasic
{
    public class LogOutBasicUserCommandHandler : IRequestHandler<LogOutBasicUserCommand,string>
    {
        private readonly IIDentityRepository repository;

        public LogOutBasicUserCommandHandler(IIDentityRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(LogOutBasicUserCommand request, CancellationToken cancellationToken)
        {
            return await repository.LogOut("BasicAthentication");
        }
    }
}
