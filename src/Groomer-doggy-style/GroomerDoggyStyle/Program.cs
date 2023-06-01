using GroomerDoggyStyle.Infrastructure.Configurations;
using GroomerDoggyStyle.Application.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

app.Run();
