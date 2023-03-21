using Btc.Instructions.Domain.Enums;

namespace Btc.Instructions.Domain.Dtos.Instruction
{
    public class AddInstructionDto
    {
        public int UserId { get; set; }
        public int DayOfMonth { get; set; }
        public List<InstructionNotificationType> NotificationTypes { get; set; }
        public decimal InstructionAmount { get; set; }
    }
}
