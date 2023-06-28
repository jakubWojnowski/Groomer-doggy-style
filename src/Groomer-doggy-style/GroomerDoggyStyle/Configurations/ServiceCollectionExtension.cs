using GroomerDoggyStyle.Api.Middleware;

namespace GroomerDoggyStyle.Api.Configurations;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddScoped<ExceptionMiddleware>();

        return services;
    }
}
