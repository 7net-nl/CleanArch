using CleanArchitecture.Domain.Contract.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogOut
{
    public class LogOutUserCommandHandler : IRequestHandler<LogOutUserCommand,string>
    {
        private readonly IIDentityRepository repository;

        public LogOutUserCommandHandler(IIDentityRepository repository)
        {
            this.repository = repository;
        }
        public async Task<string> Handle(LogOutUserCommand request, CancellationToken cancellationToken)
        {
          var Result =  await repository.LogOut();


            return Result;

           

        }
    }
}
