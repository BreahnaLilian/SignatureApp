using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignatureApplication.Common;

namespace SignaturePersistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersitance(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<SignatureDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SignatureDatabase")));

            //if (!string.IsNullOrWhiteSpace(configuration.GetConnectionString("SignatureDatabasePostgreSQL")))
            //{
            //    services.AddDbContext<SignatureDbContext>(options =>
            //    options.UseNpgsql(configuration.GetConnectionString("SignatureDatabasePostgreSQL")));
            //}

            services.AddStackExchangeRedisCache(options =>
            options.Configuration = configuration.GetConnectionString("SignatureCache"));

            services.AddScoped<ISignatureDbContext>(provider => provider.GetService<SignatureDbContext>());

            return services;
        }
    }
}
