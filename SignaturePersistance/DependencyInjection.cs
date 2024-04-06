using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignaturePersistance.Configurations;

namespace SignaturePersistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersitance(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<SignatureDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("RiskConnection")));



            return services;
        }
    }
}
