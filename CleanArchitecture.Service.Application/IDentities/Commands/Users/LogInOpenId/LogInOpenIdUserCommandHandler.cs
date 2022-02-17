using CleanArchitecture.Domain.Contract.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOpenId
{
    public class LogInOpenIdUserCommandHandler : IRequestHandler<LogInOpenIdUserCommand,string>
    {
        private readonly IIDentityRepository repository;

        public LogInOpenIdUserCommandHandler(IIDentityRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(LogInOpenIdUserCommand request, CancellationToken cancellationToken)
        {
           var Result = await repository.ExternalLogin();

            return Result;
        }
    }
}
