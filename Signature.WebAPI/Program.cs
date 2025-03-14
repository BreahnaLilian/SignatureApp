using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Serilog;
using Signature.WebAPI.API;
using Signature.WebAPI.Swagger;
using SignatureApplication;
using SignatureInfrastructure;
using SignaturePersistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

//Add Fluent Validation
builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Use the new Swagger configuration

builder.Services
    .AddSwagger()
    // .AddApiKeyBehavior()
    //.AddBasicAuthApiBehavior()
    .AddApplication()
    .AddInfrastructure()
    .AddPersitance(builder.Configuration);

builder.Host.UseSerilog((context, configuration) =>
configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        //c.MaxDisplayedTags();
        //c.ShowExtensions();
        c.DisplayRequestDuration(); // This shows request duration in the UI
        c.ShowExtensions();         // This shows extensions (e.g., `x-` fields)
        c.DefaultModelsExpandDepth(-1); // Disable the default expansion of models
        c.EnableDeepLinking();      // Enable deep linking for tags and operations
        //c.EnableFilter();           // Enable the filter feature in Swagger UI
    });
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
