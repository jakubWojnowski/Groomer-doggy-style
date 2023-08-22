using FluentValidation.AspNetCore;
using GroomerDoggyStyle.Api.Middleware;
using GroomerDoggyStyle.Application.Address.DTO;
using GroomerDoggyStyle.Application.Employee.Validators;

namespace GroomerDoggyStyle.Api.Configurations;

public static class ServiceCollectionExtension
{

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddScoped<ExceptionMiddleware>();
      
    
       
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "GroomerDoggyStyle", Version = "v1" });
        });

        return services;
    }
}
