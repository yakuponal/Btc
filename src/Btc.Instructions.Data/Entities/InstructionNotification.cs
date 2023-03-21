namespace Btc.Instructions.Data.Entities
{
    public class InstructionNotification
    {
        public int Id { get; set; }
        public int InstructionId { get; set; }
        public int Type { get; set; }
        public bool IsActive { get; set; }
    }
}
