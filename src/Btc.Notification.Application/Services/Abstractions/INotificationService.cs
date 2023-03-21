using Btc.Notification.Domain.Enums;

namespace Btc.Notification.Application.Services.Abstractions
{
    public interface INotificationService
    {
        Task Send(InstructionNotificationType type);
    }
}
