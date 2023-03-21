using Btc.Notification.Data.Entities.Abstractions;

namespace Btc.Notification.Data.Entities
{
    public class Notification : IEntity
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int InstructionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Type { get; set; }
        public string Message { get; set; }
    }
}
