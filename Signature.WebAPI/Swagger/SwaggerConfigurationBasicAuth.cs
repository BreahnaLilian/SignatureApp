using Microsoft.OpenApi.Models;

namespace Signature.WebAPI.Swagger
{
    public static class SwaggerConfigurationBasicAuth
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Signature App", Version = "v1" }));

            return services;
        }
    }
}
