using GroomerDoggyStyle.Api.Middleware;

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
