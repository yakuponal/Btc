using System.ComponentModel.DataAnnotations.Schema;

namespace Btc.Instructions.Data.Entities
{
    public class Instruction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DayOfMonth { get; set; }
        public decimal InstructionAmount { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("InstructionId")]
        public List<InstructionNotification> Notifications { get; set; }
    }
}
