using Btc.Notification.Application.Messaging.RabbitMQ.Abstractions;
using Btc.Notification.Domain.Enums;

namespace Btc.Notification.Consumer.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static void UseMessaging(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var consumer = scope.ServiceProvider.GetRequiredService<IRabbitMQConsumer>();

            consumer.ConsumeInstructionMessage(InstructionNotificationType.Sms);
            consumer.ConsumeInstructionMessage(InstructionNotificationType.Email);
            consumer.ConsumeInstructionMessage(InstructionNotificationType.PushNotification);
        }
    }
}
