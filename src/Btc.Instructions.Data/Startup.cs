using Btc.Instructions.Data.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Btc.Instructions.Data
{
    public static class Startup
    {
        public static void AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContext(configuration);

            services.AddRepositories();
        }
    }
}
