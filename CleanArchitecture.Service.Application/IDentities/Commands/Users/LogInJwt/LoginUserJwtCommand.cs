﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInJwt
{
    public class LoginUserJwtCommand : IRequest<LoginUserJwtCommandRespons>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
