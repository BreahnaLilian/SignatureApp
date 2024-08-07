﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace SignatureApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
