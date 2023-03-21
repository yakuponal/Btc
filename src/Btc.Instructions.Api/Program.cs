using Btc.Instructions.Api.Infrastructure.Filters;
using Btc.Instructions.Api.Models.Requests.Instruction;
using Btc.Instructions.Application;
using Btc.Instructions.Data;
using FluentValidation.AspNetCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options =>
    {
        options.Filters.Add(typeof(ExceptionFilter));
        options.Filters.Add(typeof(ValidationFilter));
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    })
    .ConfigureApiBehaviorOptions(x => x.SuppressModelStateInvalidFilter = true);
builder.Services.AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<AddInstructionRequest>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddDbServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
