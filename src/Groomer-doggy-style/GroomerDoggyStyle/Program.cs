using GroomerDoggyStyle.Infrastructure.Configurations;
using GroomerDoggyStyle.Application.Configurations;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);


var app = builder.Build();
;
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();
