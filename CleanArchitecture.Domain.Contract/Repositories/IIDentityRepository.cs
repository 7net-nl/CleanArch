using CleanArchitecture.Domain.Contract.Interfaces.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Contract.Repositories
{
    public interface IIDentityRepository
    {
        Task<string> Register(string Email, string Password);
        Task<string> LogIn(IUsers users,string Password);
        Task<string> LogIn(IUsers users, string Password, ClaimsIdentity claimsIdentity, string AuthenticationScheme);
        Task<IUsers> UserExist(string Email);
        Task<string> LogOut();
        Task<string> LogOut(string AuthenticationScheme = "");
        Task<string> ExternalLogin();
    }
}
