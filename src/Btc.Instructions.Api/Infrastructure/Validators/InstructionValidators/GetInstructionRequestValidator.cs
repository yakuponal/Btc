using Btc.Instructions.Api.Models.Requests.Instruction;
using FluentValidation;

namespace Btc.Instructions.Api.Infrastructure.Validators.InstructionValidators
{
    public class GetInstructionRequestValidator : AbstractValidator<GetInstructionRequest>
    {
        public GetInstructionRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
