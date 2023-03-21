using FluentValidation;

namespace Btc.Instructions.Application.Queries.Instruction.GetInstruction
{
    internal class InstructionQueryValidator : AbstractValidator<InstructionQuery>
    {
        public InstructionQueryValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
