using Btc.Instructions.Api.Models.Requests.Instruction;
using FluentValidation;

namespace Btc.Instructions.Api.Infrastructure.Validators.InstructionValidators
{
    public class DeleteInstructionRequestValidator : AbstractValidator<DeleteInstructionRequest>
    {
        public DeleteInstructionRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.InstructionId).GreaterThan(0);
        }
    }
}
