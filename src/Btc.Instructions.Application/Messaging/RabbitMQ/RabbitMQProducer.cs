using Btc.Instructions.Application.Messaging.RabbitMQ.Abstractions;
using Btc.Instructions.Domain.Enums;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Btc.Instructions.Application.Messaging.RabbitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        public void SendInstructionMessage<T>(T message, InstructionNotificationType notificationType)
        {
            var factory = new ConnectionFactory
            {
                HostName = "rabbitmqbroker"
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare($"instruction.notification.{notificationType}",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "",
                routingKey: $"instruction.notification.{notificationType}",
                basicProperties: null,
                body: body);
        }
    }
}
