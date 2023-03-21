using Btc.Notification.Application.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Btc.Notification.Application
{
    public static class Startup
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConsumers();

            services.AddMappings();

            services.AddServices();
        }
    }
}
