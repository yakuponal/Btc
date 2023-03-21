namespace Btc.Instructions.Domain.Dtos.Instruction
{
    public class InstructionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DayOfMonth { get; set; }
        public decimal InstructionAmount { get; set; }
        public bool IsActive { get; set; }
        public List<InstructionNotificationDto> Notifications { get; set; }
    }
}
