using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignatureApplication.Common;

namespace SignaturePersistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersitance(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionStringSql = configuration.GetConnectionString("SignatureDatabase");
            string connectionStringCache = configuration.GetConnectionString("SignatureCache");
            
            services.AddLinqToDBContext<SignatureDbContext>((_, options) =>
                options
                    .UseSqlServer(connectionStringSql!));
                // .UseDefaultLogging(provider));

            services.AddStackExchangeRedisCache(options =>
                options.Configuration = connectionStringCache);

            services.AddScoped<ISignatureDbContext>(provider => provider.GetService<SignatureDbContext>());

            return services;
        }
    }
}