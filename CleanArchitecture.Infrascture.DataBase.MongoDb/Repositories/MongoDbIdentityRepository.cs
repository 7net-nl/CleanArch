using CleanArchitecture.Domain.Contract.Interfaces.EF;
using CleanArchitecture.Domain.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.DataBase.MongoDb.Repositories
{
    public class MongoDbIdentityRepository : IIDentityRepository
    {
        public Task<string> Register(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<string> LogIn(IUsers users, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<string> LogIn(IUsers users, string Password, ClaimsIdentity claimsIdentity, string AuthenticationScheme)
        {
            throw new NotImplementedException();
        }

        public Task<IUsers> UserExist(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<string> LogOut()
        {
            throw new NotImplementedException();
        }

        public Task<string> LogOut(string AuthenticationScheme = "")
        {
            throw new NotImplementedException();
        }

        public Task<string> ExternalLogin()
        {
            throw new NotImplementedException();
        }
    }
}
