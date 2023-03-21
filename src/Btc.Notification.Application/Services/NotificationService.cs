using Btc.Notification.Application.Services.Abstractions;
using Btc.Notification.Domain.Enums;

namespace Btc.Notification.Application.Services
{
    public class NotificationService : INotificationService
    {
        public async Task Send(InstructionNotificationType type)
        {
            await Task.CompletedTask;
        }
    }
}
