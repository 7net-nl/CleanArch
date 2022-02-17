using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using System.Reflection;
using CleanArchitecture.Service.Application.Common.Behaviors;
using CleanArchitecture.Service.Application.Common.Paginations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CleanArchitecture.Domain.Contract.Constants;

namespace CleanArchitecture.Service.Application
{
    public static class ApplicationExtension
    {
        public static void AddApplicationDependency(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BehaviorLogger<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BehaviorUnhandleException<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BehaviorValidation<,>));

           




        }
    }
}
