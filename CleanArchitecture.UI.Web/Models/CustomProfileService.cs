using CleanArchitecture.UI.Web.Data;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CleanArchitecture.UI.Web.Models
{
    public class CustomProfileService : IProfileService
    {
        private readonly UserManager<Users> userManager;

        public CustomProfileService(UserManager<Users> userManager)
        {
            this.userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var MyUser = await userManager.GetUserAsync(context.Subject);
            var Claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Name,MyUser.UserName),
                new Claim(JwtClaimTypes.Email,MyUser.Email),
                new Claim(JwtClaimTypes.Role, "Admin")
            };

            context.IssuedClaims.AddRange(Claims);

            await Task.FromResult(0);

            
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var MyUser = await userManager.GetUserAsync(context.Subject);
            context.IsActive = MyUser != null;

            await Task.FromResult(0);
        }

        
    }
}
