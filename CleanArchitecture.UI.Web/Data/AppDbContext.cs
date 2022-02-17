using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.UI.Web.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
           
            base.OnModelCreating(builder);
        }

       

    }
}
