using Microsoft.Extensions.DependencyInjection;
using PaymentApp.Entity.DataAccess;
using PaymentApp.Repository.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentApp.Service.Implementation;
using PaymentApp.Service.Interface;

namespace PaymentApp.API.Extension
{
    public static class DependencyServiceExtentions
    {
        public static IServiceCollection AddTransientDependencyInjection(this IServiceCollection services, string profile = "default")
        {
            //#################### Service injections ##############################
            services.AddTransient<IUserService, UserService>();

            //#################### Repository injections ##############################
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //#################### Context injections ##############################
            services.AddTransient<MyDbContext>();
            

            
            return services;
        }
    }
}
