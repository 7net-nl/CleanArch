using CleanArchitecture.UI.Web.Data;
using CleanArchitecture.UI.Web.Models;
using IdentityServer4.EntityFramework.DbContexts;
using Entities = IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4;
using System.Security.Claims;
using IdentityModel;
using System.Reflection;

namespace CleanArchitecture.UI.Web.Controllers
{
    public class Home2Controller : Controller
    {
        private readonly ConfigurationDbContext Context;
        private readonly UserManager<Users> userManager;

        public Home2Controller(ConfigurationDbContext Context,UserManager<Users> userManager)
        {
            this.Context = Context;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

       public async Task<IActionResult> Seed()
        {

            //Context.AddRange(new IdentityResources.OpenId().ToEntity(), new IdentityResources.Profile().ToEntity());
            //Context.AddRange(new ApiScope("Api01", "This is Example").ToEntity());
            //Context.AddRange(
            //    new Client
            //    {
            //        ClientId = "client",
            //        ClientSecrets = { new Secret("secret".Sha256()) },
            //        AllowedGrantTypes = GrantTypes.ClientCredentials,
            //        AllowedScopes = { "Api01" }
            //    }.ToEntity()

            //new Client
            //{
            //    ClientId = "mvc10",
            //    ClientSecrets = { new Secret("secret".Sha256()) },
            //    RedirectUris = { "https://localhost:44367/api/external/check" },
            //    AllowedGrantTypes = GrantTypes.Code,
            //    AllowedScopes =
            //    {
            //         IdentityServerConstants.StandardScopes.OpenId,
            //          IdentityServerConstants.StandardScopes.Profile,
            //          IdentityServerConstants.StandardScopes.Email,
            //          JwtClaimTypes.Name,
            //          JwtClaimTypes.Email,
            //          JwtClaimTypes.Role

            //    },
            //    RequirePkce = true,
            //    AllowPlainTextPkce = false,
            //    AlwaysIncludeUserClaimsInIdToken = true,
            //    AlwaysSendClientClaims = true,


            //}.ToEntity()

            //);

            //Context.AddRange(new ApiResource("Api03", "Example Api03").ToEntity());

            //var MyUser = new Users
            //{
            //    Email = "mail@gmail.com",
            //    UserName = "UserName"
            //};

            //var ResultUser = await userManager.CreateAsync(MyUser, "Admin@123456");
            //var Claims = new List<Claim>
            //{
            //    new Claim(JwtClaimTypes.Name,MyUser.UserName),
            //    new Claim(JwtClaimTypes.Email,MyUser.Email),
            //    new Claim(JwtClaimTypes.Role,"Admin")

            //};

            //await userManager.AddClaimsAsync(MyUser, Claims);


            //Context.SaveChanges();
            
            return Ok("True");
        }
    }
}
