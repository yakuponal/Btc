using Btc.Notification.Application.Messaging.RabbitMQ.Abstractions;
using Btc.Notification.Application.Services.Abstractions;
using Btc.Notification.Data.Repositories.Abstractions;
using Btc.Notification.Domain.Enums;
using Btc.Notification.Domain.Models;
using Mapster;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Entity = Btc.Notification.Data.Entities;

namespace Btc.Notification.Application.Messaging.RabbitMQ
{
    public class RabbitMQConsumer : IRabbitMQConsumer
    {
        private readonly IRepository<Entity.Notification> _notificationRepository;
        private readonly INotificationService _notificationService;

        public RabbitMQConsumer(
            IRepository<Entity.Notification> notificationRepository,
            INotificationService notificationService)
        {
            _notificationRepository = notificationRepository;
            _notificationService = notificationService;
        }

        public void ConsumeInstructionMessage(InstructionNotificationType notificationType)
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

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                if (!string.IsNullOrEmpty(message))
                {
                    var notificationMessage = JsonConvert.DeserializeObject<NotificationMessage>(message);

                    var notification = notificationMessage.Adapt<Entity.Notification>();
                    notification.Type = (int)notificationType;

                    await _notificationRepository.CreateAsync(notification);
                    await _notificationService.Send(notificationType);

                    Console.WriteLine($"Instruction message received: {message}");
                }
            };

            channel.BasicConsume(queue: $"instruction.notification.{notificationType}", autoAck: true, consumer: consumer);
        }
    }
}
