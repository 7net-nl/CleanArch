using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Infrascture.DataBase.Fake.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanArchitecture.Infrascture.DataBase.Fake
{
    public static class FakeDataBaseExtension
    {
        public static void AddFakeDataBaseDependency(this IServiceCollection services)
        {
            services.AddTransient<IBaseRepository, FakeBaseRepository>();
            services.AddTransient<IIDentityRepository, FakeIdentityRepository>();
        }
    }
}
