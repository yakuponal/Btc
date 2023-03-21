namespace Btc.Notification.Domain.Models
{
    public class NotificationMessage
    {
        public int UserId { get; set; }
        public int InstructionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Message { get; set; }
    }
}
