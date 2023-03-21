using Btc.Notification.Data.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Entity = Btc.Notification.Data.Entities;

namespace Btc.Notification.Data
{
    public static class Startup
    {
        public static void AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongo(configuration);

            services.AddMongoRepository<Entity.Notification>("notifications");
        }
    }
}
