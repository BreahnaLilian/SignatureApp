using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SignatureApplication;
using SignatureInfrastructure;
using SignaturePersistance;
using System.Text.Json.Serialization;
using static SignatureCommon.Enums;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
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
    })
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
builder.Services.AddSwaggerGen();


builder.Services
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
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
