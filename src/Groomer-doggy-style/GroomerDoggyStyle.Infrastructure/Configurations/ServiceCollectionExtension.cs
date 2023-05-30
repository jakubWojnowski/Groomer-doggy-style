using GroomerDoggyStyle.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GroomerDoggyStyle.Infrastructure.Configurations
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<GroomerDoggyStyleDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("GroomerDoggyStyle")));
        }
    }
}
