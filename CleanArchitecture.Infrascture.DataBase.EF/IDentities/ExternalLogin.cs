using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.DataBase.EF.IDentities
{
    public class ExternalLogin
    {

       
        public async Task<bool> UserAuthenticate(SignInManager<Users> signInManager,UserManager<Users> userManager)
        {
            
            var MyUser = await userManager.FindByIdAsync(signInManager.Context.User?.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            return MyUser != null ? true : await RegisterUser(signInManager,userManager);
            
        }

        public async Task<bool> UserNoAuthenticate()
        {
            return await Task.FromResult(false);
        }

        public async Task<bool> RegisterUser(SignInManager<Users> signInManager,UserManager<Users> userManager)
        {

           var Identity = signInManager.Context.User;
           

            var NewUser = new Users
            {
                 Id = Identity.FindFirstValue(ClaimTypes.NameIdentifier),
                 Email = Identity.FindFirstValue(ClaimTypes.Email),
                 UserName = Identity.FindFirstValue(ClaimTypes.Name) 
            };

            var Password = new UserRandomPassword().Get();

           var Result =  await userManager.CreateAsync(NewUser,Password);

            return Result.Succeeded;
        }
    }
}
