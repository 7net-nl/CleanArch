using CleanArchitecture.Domain.Contract.Constants;
using CleanArchitecture.UI.Web.Data;
using CleanArchitecture.UI.Web.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CleanArchitecture.UI.Web
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
            services.AddControllersWithViews();

           
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(DataBaseConstant.SqliteIDentityServer,c=>c.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));
            services.AddIdentity<Users, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer()
               .AddOperationalStore(c =>
               {
                   c.ConfigureDbContext = d => d.UseSqlite(DataBaseConstant.SqliteIDentityServer, c => c.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
               })
               .AddConfigurationStore(e =>
               {
                   e.ConfigureDbContext = f => f.UseSqlite(DataBaseConstant.SqliteIDentityServer, c => c.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
               })
              .AddDeveloperSigningCredential()
              .AddAspNetIdentity<Users>()
              .AddProfileService<CustomProfileService>();
            
              
              








        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.AppDbContextSeed();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthorization();

          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
