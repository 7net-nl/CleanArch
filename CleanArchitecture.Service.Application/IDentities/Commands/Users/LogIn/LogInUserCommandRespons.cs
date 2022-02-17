using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogIn
{
    public class LogInUserCommandRespons
    {
        public string Result { get; set; }
        public ClaimsIdentity ClaimsIdentity { get; set; }
    }
}
