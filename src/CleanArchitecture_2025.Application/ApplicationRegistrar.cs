using Microsoft.Extensions.DependencyInjection;
using System;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_2025.Application
{
    public static class ApplicationRegistrar
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(typeof(ApplicationRegistrar).Assembly);
                conf.AddOpenBehavior(typeof(Behaviors.ValidationBehavior<,>));
            });
            services.AddValidatorsFromAssembly(typeof(ApplicationRegistrar).Assembly);
            return services;
        }
    }
}
