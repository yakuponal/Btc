using Btc.Instructions.Application.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Btc.Instructions.Application
{
    public static class Startup
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDependencies(configuration);
            
            services.AddRules();

            services.AddMappings();

            services.AddManagers();
        }
    }
}
