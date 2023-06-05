using GroomerDoggyStyle.Infrastructure.Configurations;
using GroomerDoggyStyle.Application.Configurations;
using GroomerDoggyStyle.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
