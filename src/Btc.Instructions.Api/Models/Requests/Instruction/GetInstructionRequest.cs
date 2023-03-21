using Btc.Instructions.Domain.Enums;

namespace Btc.Instructions.Api.Models.Requests.Instruction
{
    public class GetInstructionRequest
    {
        public int UserId { get; set; }
        public InstructionIncludeType Include { get; set; }
    }
}
