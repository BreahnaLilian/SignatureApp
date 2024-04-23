using Microsoft.Extensions.DependencyInjection;
using SignatureApplication.Common.Interfaces;
using SignatureInfrastructure.Services;

namespace SignatureInfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICacheService, CacheService>();

            return services;
        }
    }
}
