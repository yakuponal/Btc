using Btc.Instructions.Domain.Dtos.Instruction;
using MediatR;

namespace Btc.Instructions.Application.Commands.Instruction.AddInstruction
{
    public class AddInstructionCommand : AddInstructionDto, IRequest<Unit>
    {
    }
}
