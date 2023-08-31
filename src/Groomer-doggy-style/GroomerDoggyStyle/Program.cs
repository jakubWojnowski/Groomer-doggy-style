using FluentValidation.AspNetCore;
using GroomerDoggyStyle.Infrastructure.Configurations;
using GroomerDoggyStyle.Application.Configurations;
using GroomerDoggyStyle.Api.Middleware;
using GroomerDoggyStyle.Api.Configurations;
using GroomerDoggyStyle.Application.Employee.Validators;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

builder.Services.AddControllers();


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GroomerDoggyStyle"));
app.Run();
