using IdentityModel;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOpenId
{
    public static class AuthenticationOpenIdExtension
    {
        public static void AddAuthenticationOpenId(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = "oidc";


            }).AddCookie().AddOpenIdConnect("oidc", opt =>
            {
                opt.ClientId = "mvc10";
                opt.ClientSecret = "secret";
                opt.Authority = "https://localhost:44326";
                opt.CallbackPath = "/api/external/check";
                opt.ResponseType = "code";
                opt.SaveTokens = true;
                opt.UsePkce = true;
                opt.ResponseMode = "query";
                opt.GetClaimsFromUserInfoEndpoint = true;
                opt.MapInboundClaims = true;



            });


            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/api/external/Identity";
                opt.ExpireTimeSpan = new TimeSpan(0, 30, 0);

            });

            //services.AddAuthentication(opt=>
            //{
            //    opt.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            //    opt.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            //})
            //    .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, opt =>
            //     {
            //         opt.ApiName = "Api01";
            //         opt.Authority = "https://localhost:44326";
            //         opt.ApiSecret = "Secret01";




            //     });

        }
    }
}
