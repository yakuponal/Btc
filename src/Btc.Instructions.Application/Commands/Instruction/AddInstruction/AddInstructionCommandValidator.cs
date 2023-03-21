using FluentValidation;

namespace Btc.Instructions.Application.Commands.Instruction.AddInstruction
{
    public class AddInstructionCommandValidator : AbstractValidator<AddInstructionCommand>
    {
        public AddInstructionCommandValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.InstructionAmount).GreaterThan(0);
        }
    }
}
