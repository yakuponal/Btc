using Btc.Instructions.Domain.Enums;

namespace Btc.Instructions.Domain.Dtos.Instruction
{
    public class InstructionNotificationDto
    {
        public int Id { get; set; }
        public int InstructionId { get; set; }
        public InstructionNotificationType Type { get; set; }
        public bool IsActive { get; set; }
    }
}
