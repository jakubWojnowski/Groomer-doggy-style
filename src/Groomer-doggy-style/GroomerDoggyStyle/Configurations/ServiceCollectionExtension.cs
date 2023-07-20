using FluentValidation.AspNetCore;
using GroomerDoggyStyle.Api.Middleware;
using GroomerDoggyStyle.Application.Address.DTO;

namespace GroomerDoggyStyle.Api.Configurations;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddScoped<ExceptionMiddleware>();
        // services.AddFluentValidation(cfg =>
        // {
        //     cfg.RegisterValidatorsFromAssemblyContaining<AddressDto>(); // Upewnij się, że poprawna klasa DTO jest wskazana
        // });

       
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "GroomerDoggyStyle", Version = "v1" });
        });

        return services;
    }
}
