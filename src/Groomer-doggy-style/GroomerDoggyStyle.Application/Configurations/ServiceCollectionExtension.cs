using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GroomerDoggyStyle.Application.Configurations;

public static class ServiceCollectionExtension
{
 
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.RegisterServicesFromAssembly(Assembly.Load("GroomerDoggyStyle.Application.Owners"));
            cfg.RegisterServicesFromAssembly(Assembly.Load("GroomerDoggyStyle.Application.Dogs"));
            cfg.RegisterServicesFromAssembly(Assembly.Load("GroomerDoggyStyle.Application.Address"));
            cfg.RegisterServicesFromAssembly(Assembly.Load("GroomerDoggyStyle.Application.Employee"));
            cfg.RegisterServicesFromAssembly(Assembly.Load("GroomerDoggyStyle.Application.GroomerShops"));
            cfg.RegisterServicesFromAssembly(Assembly.Load("GroomerDoggyStyle.Application.Offers"));
            cfg.RegisterServicesFromAssembly(Assembly.Load("GroomerDoggyStyle.Application.Visits"));
        });
        return services;
    }
}
