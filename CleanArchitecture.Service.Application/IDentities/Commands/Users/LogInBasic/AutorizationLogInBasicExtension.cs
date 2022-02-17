using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInBasic
{
    public static class AutorizationLogInBasicExtension
    {
        public static void AddAutorizationBasic(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = "BasicAthentication";
                opt.DefaultChallengeScheme = "BasicAthentication";
            }).AddCookie("BasicAthentication");
        }
    }
}
