using Btc.Instructions.Domain.Dtos.Instruction;
using MediatR;

namespace Btc.Instructions.Application.Commands.Instruction.DeleteInstruction
{
    public class DeleteInstructionCommand : DeleteInstructionDto, IRequest<Unit>
    {
    }
}
