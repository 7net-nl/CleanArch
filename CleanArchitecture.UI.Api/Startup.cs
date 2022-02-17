using CleanArchitecture.Service.Application;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CleanArchitecture.Domain.Contract.Constants;
using Microsoft.AspNetCore.Http;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInApiKey;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInBasic;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInJwt;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOAuth;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOAuth.Google;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOAuth.GitHub;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOAuth.FaceBook;
using CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInOpenId;
using CleanArchitecture.Infrascture.DataBase.MongoDb;
using CleanArchitecture.Infrascture.DataBase.EF;
using CleanArchitecture.Infrascture.DataBase.Fake;
using Hangfire;
using Hangfire.SQLite;
using CleanArchitecture.Infrascture.Common.HangFires;

namespace CleanArchitecture.UI.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddFluentValidation().AddSessionStateTempDataProvider();
           services.AddApplicationDependency();
            services.AddDataBaseEFDependency();
           //services.AddMongoDbDependency();
            //services.AddAuthenticationOpenId();

            services.AddHangFireService();

            services.AddSession();
            services.AddDistributedMemoryCache();






        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }


           
            app.UseCookiePolicy();
            app.UseSession();
            app.UseStatusCodePages();
            app.UseRouting();
            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseHangfireDashboard();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
               
            });
        }
    }
}
