using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOAuth.FaceBook
{
    public static class AutenticationFaceBookExtension
    {
        public static void AddAuteticationFaceBook(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = "Facebook";
            }).AddCookie()
            .AddFacebook(opt =>
            {
                opt.AppId = "1111111";
                opt.AppSecret = "111111111";
                opt.CallbackPath = "/api/external/Check";
                opt.CorrelationCookie.SameSite = SameSiteMode.Unspecified;
            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/api/external/FaceBook";
                opt.ExpireTimeSpan = new TimeSpan(0, 30, 0);
            });
        }
    }
}
