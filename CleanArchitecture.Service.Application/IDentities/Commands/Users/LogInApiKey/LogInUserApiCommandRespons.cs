using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInApiKey
{
    public class LogInUserApiCommandRespons
    {
        public string Token { get; set; }
        public string Result { get; set; }
        public string Email { get; set; }

    }
}
