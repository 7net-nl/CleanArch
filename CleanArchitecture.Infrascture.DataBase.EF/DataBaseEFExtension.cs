using CleanArchitecture.Domain.Contract.Constants;
using CleanArchitecture.Domain.Contract.Interfaces;
using CleanArchitecture.Domain.Contract.Interfaces.EF;
using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Infrascture.DataBase.EF.IDentities;
using CleanArchitecture.Infrascture.DataBase.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanArchitecture.Infrascture.DataBase.EF
{
    public static class DataBaseEFExtension
    {
        public static void AddDataBaseEFDependency(this IServiceCollection services)
        {
    
           services.AddDbContext<DBContextEF>(opt => opt.UseSqlite(DataBaseConstant.SqliteConnectionString));
            services.AddDbContext<DbContextIDentityEF>(opt => opt.UseSqlite(DataBaseConstant.SqliteConnectionStringIDentity));
            services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<DbContextIDentityEF>().AddDefaultTokenProviders();
            services.AddScoped<IBaseRepository, EFBaseRepository>();
            services.AddScoped<IIDentityRepository, EFIDentityRepository>();
           services.AddTransient<IUsers, Users>();
            
        }
    }
}
