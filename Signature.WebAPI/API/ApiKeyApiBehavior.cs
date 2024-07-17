using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

namespace Signature.WebAPI.API;

public static class ApiKeyApiBehavior
{
    public static IServiceCollection AddApiKeyBehavior(this IServiceCollection services)
    {
        services.AddAuthentication("ApiKey")
            .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("ApiKey", null);

        services.AddSwaggerGen(c =>
        {
            // Add the API Key auth definition
            c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "X-API-KEY",
                Type = SecuritySchemeType.ApiKey,
                Description = "API Key Authentication"
            });

            // Add the requirement to use API Key
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}
