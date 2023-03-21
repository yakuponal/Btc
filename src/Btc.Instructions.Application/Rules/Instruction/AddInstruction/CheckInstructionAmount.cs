using Btc.Instructions.Application.Rules.Instruction.AddInstruction.Abstractions;
using Btc.Instructions.Application.Rules.Models;
using Btc.Instructions.Domain.Dtos.Instruction;
using Btc.Instructions.Domain.Resources;

namespace Btc.Instructions.Application.Rules.Instruction.AddInstruction
{
    internal class CheckInstructionAmount : Rule, IAddInstructionRule
    {
        public CheckInstructionAmount(IAddInstructionRule next)
        {
            Next = next;
        }

        public async Task<RuleResult> Run(object model)
        {
            var ruleModel = model as AddInstructionDto;

            var isValidAmount = ruleModel.InstructionAmount >= 100 && ruleModel.InstructionAmount <= 20000;

            return new RuleResult
            {
                Success = isValidAmount,
                Message = !isValidAmount ? ErrorResources.InvalidInstructionAmount : null
            };
        }
    }
}
