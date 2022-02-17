using Entities = IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Identity;
using IdentityModel;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.UI.Web.Data
{
    public static class ApplicationBuilderExtension 
    {
        public async static void AppDbContextSeed(this IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
                var Context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                var MyUserManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Users>>();

                Context.Add<Entities.Client>(new Client
                {
                    ClientId = "oauthClient",
                    ClientName = "Example client application using client credentials",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> { new Secret("GGTEW@#$*".Sha256()) },
                    AllowedScopes = new List<string> { "api1.read", "api1.write" }

                }.ToEntity());

                Context.Add(new Client
                {
                    ClientId = "oidcClient",
                    ClientName = "Example Client Application",
                    ClientSecrets = new List<Secret> { new Secret("SuperSecretPassword".Sha256()) }, // change me!

                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> { "http://localhost:20425/signin-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "api1.read"
                    },

                    RequirePkce = true,
                    AllowPlainTextPkce = false
                }.ToEntity());

                Context.AddRange(
                    new IdentityResources.OpenId().ToEntity(),
                    new IdentityResources.Profile().ToEntity(),
                    new IdentityResources.Email().ToEntity(),
                     new IdentityResource
                     {
                         Name = "role",
                         UserClaims = new List<string> { "role" }
                     }.ToEntity()
                    );
                Context.AddRange(new ApiResource
                {
                    Name = "api1",
                    DisplayName = "API #1",
                    Description = "Allow the application to access API #1 on your behalf",
                    Scopes = new List<string> { "api1.read", "api1.write" },
                    ApiSecrets = new List<Secret> { new Secret("ScopeSecret".Sha256()) }, // change me!
                    UserClaims = new List<string> { "role" }
                }.ToEntity());

                Context.AddRange(
                    new ApiScope("api1.read", "Read Access to API #1").ToEntity(),
                    new ApiScope("api1.write", "Write Access to API #1").ToEntity());

                var MyUser = new Users
                {
                    Id = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    UserName = "google@gmail.com",
                    Email = "google@gmail.com"
                };

                var UserClaim = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "google@gmail.com"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    };

                await MyUserManager.CreateAsync(MyUser, "Admin@123");

                await MyUserManager.AddClaimsAsync(MyUser, UserClaim);

                Context.SaveChanges();
            }
        }
    }
}
