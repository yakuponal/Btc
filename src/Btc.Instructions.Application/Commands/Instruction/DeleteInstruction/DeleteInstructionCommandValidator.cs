using FluentValidation;

namespace Btc.Instructions.Application.Commands.Instruction.DeleteInstruction
{
    public class DeleteInstructionCommandValidator : AbstractValidator<DeleteInstructionCommand>
    {
        public DeleteInstructionCommandValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.InstructionId).GreaterThan(0);
        }
    }
}
