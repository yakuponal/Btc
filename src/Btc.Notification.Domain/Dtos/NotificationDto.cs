using Btc.Notification.Domain.Enums;

namespace Btc.Notification.Domain.Dtos
{
    public class NotificationDto
    {
        public int UserId { get; set; }
        public int InstructionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public InstructionNotificationType NotificationType { get; set; }
        public string Message { get; set; }
    }
}
