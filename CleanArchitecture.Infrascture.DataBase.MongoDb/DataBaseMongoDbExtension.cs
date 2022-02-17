using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Infrascture.DataBase.MongoDb.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.DataBase.MongoDb
{
    public static class DataBaseMongoDbExtension
    {
        public static void AddMongoDbDependency(this IServiceCollection services)
        {
            services.AddScoped<MongoDbContext>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IBaseRepository, MongoDbBaseRepository>();
            services.AddScoped<IIDentityRepository,MongoDbIdentityRepository>();
        }
    }
}
