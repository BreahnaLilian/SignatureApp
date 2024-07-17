using Microsoft.AspNetCore.Mvc;
using static SignatureCommon.Enums;

namespace Signature.WebAPI.API.Behavior;

public static class ValidationApiBehavior
{
    public static IServiceCollection AddValidationApiBehavior(this IServiceCollection services)
    {
        services.AddControllers()    
            .ConfigureApiBehaviorOptions(options =>
            
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => new
                    {
                        Name = e.Key,
                        Message = e.Value.Errors.First().ErrorMessage
                    }).ToArray();

                    var responseObj = new
                    {
                        Result = ExecutionResult.NOTVALID,
                        Message = "One or more validation errors occurred.",
                        Errors = errors,
                        ShowToast = true,
                    };

                    return new OkObjectResult(responseObj);
                };
            });

        return services;
    }
}
