using Microsoft.Extensions.DependencyInjection;
using PaymentApp.Entity.DataAccess;
using PaymentApp.Repository.UnitOfWorkPattern;
using PaymentApp.Service.Implementation;
using PaymentApp.Service.Interface;
using PaymentApp.APIs.Helpers;

namespace PaymentApp.APIs.Extension
{
    public static class DependencyServiceExtentions
    {
        public static IServiceCollection AddTransientDependencyInjection(this IServiceCollection services, string profile = "default")
        {
            //#################### Service injections ##############################
            services.AddTransient<IPremiumPaymentService, PremiumPaymentService>();
            services.AddTransient<IExpensivePaymentService, ExpensivePaymentService>();
            services.AddTransient<ICheapPaymentService, CheapPaymentService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IResponseFactory, ResponseFactory>();

            //#################### Repository injections ##############################
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //#################### Context injections ##############################
            services.AddTransient<PaymentDBContext>();
            
            return services;
        }
    }
}
