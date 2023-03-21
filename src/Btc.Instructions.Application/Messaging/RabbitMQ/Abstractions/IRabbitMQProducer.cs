using Btc.Instructions.Domain.Enums;

namespace Btc.Instructions.Application.Messaging.RabbitMQ.Abstractions
{
    public interface IRabbitMQProducer
    {
        public void SendInstructionMessage<T>(T message, InstructionNotificationType notificationType);
    }
}
