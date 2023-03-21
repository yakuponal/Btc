using Btc.Instructions.Api.Models.Requests.Instruction;
using FluentValidation;

namespace Btc.Instructions.Api.Infrastructure.Validators.InstructionValidators
{
    public class AddInstructionRequestValidator : AbstractValidator<AddInstructionRequest>
    {
        public AddInstructionRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.InstructionAmount).GreaterThan(0);
        }
    }
}
