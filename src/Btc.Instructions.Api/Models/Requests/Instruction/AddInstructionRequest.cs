namespace Btc.Instructions.Api.Models.Requests.Instruction
{
    public class AddInstructionRequest
    {
        public int UserId { get; set; }
        public int DayOfMonth { get; set; }
        public List<int> NotificationTypes { get; set; }
        public decimal InstructionAmount { get; set; }
    }
}
