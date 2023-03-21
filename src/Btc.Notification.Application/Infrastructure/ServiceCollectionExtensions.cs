using Btc.Notification.Application.Messaging.RabbitMQ;
using Btc.Notification.Application.Messaging.RabbitMQ.Abstractions;
using Btc.Notification.Application.Services;
using Btc.Notification.Application.Services.Abstractions;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Btc.Notification.Application.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddConsumers(this IServiceCollection services)
        {
            services.AddScoped<IRabbitMQConsumer, RabbitMQConsumer>();
        }

        public static void AddMappings(this IServiceCollection services)
        {
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}
