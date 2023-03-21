using Btc.Instructions.Domain.Enums;
using MediatR;

namespace Btc.Instructions.Application.Queries.Instruction.GetInstruction
{
    public class InstructionQuery : IRequest<InstructionQueryResult>
    {
        public int UserId { get; set; }
        public InstructionIncludeType Include { get; set; }
    }
}
