using GroomerDoggyStyle.Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GroomerDoggyStyle.Application.Configurations
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IOwnerService, OwnerService>();

            return services;
        }
    }
}
