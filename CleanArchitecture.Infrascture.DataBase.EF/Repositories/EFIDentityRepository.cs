using CleanArchitecture.Domain.Contract.Interfaces.EF;
using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Infrascture.DataBase.EF.IDentities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.DataBase.EF.Repositories
{
    public class EFIDentityRepository : IIDentityRepository
    {
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;

        public EFIDentityRepository(UserManager<Users> userManager,SignInManager<Users> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<string> LogIn(IUsers users,string Password)
        {
            
                var MyUser = await userManager.FindByEmailAsync(users.Email);

                var Result = await signInManager.PasswordSignInAsync(MyUser, Password, false, false);

                return Result.Succeeded ? "Success" : "Failed";
        }

        public async Task<string> LogIn(IUsers users, string Password, ClaimsIdentity claimsIdentity, string AuthenticationScheme)
        {
          
                var MyUser = await userManager.FindByEmailAsync(users.Email);

                var Result = await signInManager.PasswordSignInAsync(MyUser, Password, false, false);

                if (Result.Succeeded) await signInManager.Context.SignInAsync(AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return Result.Succeeded ? "Success" : "Failed";
        }

        public async Task<IUsers> UserExist(string Email)
        {
            return await userManager.FindByEmailAsync(Email);
        }

        public async Task<string> LogOut()
        {

           await  signInManager.Context.SignOutAsync();
            
            await  signInManager.SignOutAsync();

           var Result = signInManager.IsSignedIn(new ClaimsPrincipal(signInManager.Context.User));

            return Result ? "Failed" : "Success" ;
        }

        public async Task<string> LogOut(string AuthenticationScheme)
        {
           
           await signInManager.Context.SignOutAsync(AuthenticationScheme);
           await signInManager.SignOutAsync();

            var Result = signInManager.IsSignedIn(new ClaimsPrincipal(signInManager.Context.User));

            return Result ? "Failed" : "Success";
        }

        public async Task<string> Register(string Email, string Password)
        {
            var MyUser = new Users
            {
                 Id = Guid.NewGuid().ToString(),
                  SecurityStamp = Guid.NewGuid().ToString(),
                   Email = Email,
                    NormalizedEmail = Email.ToUpper(),
                     UserName = Email,
                      NormalizedUserName = Email.ToUpper()
            };

            var Result = await userManager.CreateAsync(MyUser, Password);

            return Result.Succeeded ? "Success" : "Failed";
        }

        public async Task<string> ExternalLogin()
        {
            var External = new ExternalLogin();

            var Result = signInManager.Context.User.Identity.IsAuthenticated ? External.UserAuthenticate(signInManager,userManager) : External.UserNoAuthenticate();

            return await Result ? "Success" : "Failed";
        }
    }
}
