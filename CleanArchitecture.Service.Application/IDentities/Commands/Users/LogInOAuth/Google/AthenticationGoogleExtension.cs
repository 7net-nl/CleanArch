using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOAuth.Google
{
    public static class AthenticationGoogleExtension
    {
        public static void AddAthenticationGoogle(this IServiceCollection services)
        {

            
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
               
                
               
            }).AddCookie().AddGoogle(opt =>
            {
                
                opt.ClientId = "11111.apps.googleusercontent.com";
                opt.ClientSecret = "1111111";
                opt.CallbackPath = "/api/external/Check";
                opt.SignInScheme = IdentityConstants.ExternalScheme;
                opt.CorrelationCookie.SameSite = SameSiteMode.Unspecified;
                
            



            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/api/external/google";
                opt.ExpireTimeSpan = new TimeSpan(0, 30, 0);
                
            });

         
        }
    }
}
