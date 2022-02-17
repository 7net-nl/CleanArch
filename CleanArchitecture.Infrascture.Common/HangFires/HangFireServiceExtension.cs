using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SQLite;
using CleanArchitecture.Domain.Contract.Constants;

namespace CleanArchitecture.Infrascture.Common.HangFires
{
    public static class HangFireServiceExtension
    {
        public static void AddHangFireService(this IServiceCollection services)
        {
            services.AddHangfire(opt =>
            {
                opt.UseInMemoryStorage();
                opt.UseMediator();
            });

            services.AddHangfireServer();
        }
    }
}
