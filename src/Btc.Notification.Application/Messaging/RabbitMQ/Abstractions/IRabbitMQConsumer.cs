using Btc.Notification.Domain.Enums;

namespace Btc.Notification.Application.Messaging.RabbitMQ.Abstractions
{
    public interface IRabbitMQConsumer
    {
        public void ConsumeInstructionMessage(InstructionNotificationType notificationType);
    }
}
