using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOAuth.GitHub
{
    public static class AuthenticationGithubExtension
    {
        public static void AddAutheticationGitHub(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {

                opt.DefaultAuthenticateScheme = "GitHub";
              
               

            }).AddCookie()
            .AddGitHub(opt=>
            {
                opt.ClientId = "1111111";
                opt.ClientSecret = "1111111";
                opt.CallbackPath = "/api/external/Check";
                opt.CorrelationCookie.SameSite = SameSiteMode.Unspecified;
            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/api/external/github";
                opt.ExpireTimeSpan = new TimeSpan(0, 30, 0);

            });
        }
    }
}
