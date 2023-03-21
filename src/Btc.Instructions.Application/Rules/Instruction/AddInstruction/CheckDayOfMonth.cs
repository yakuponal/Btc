using Btc.Instructions.Application.Rules.Instruction.AddInstruction.Abstractions;
using Btc.Instructions.Application.Rules.Models;
using Btc.Instructions.Domain.Dtos.Instruction;
using Btc.Instructions.Domain.Resources;

namespace Btc.Instructions.Application.Rules.Instruction.AddInstruction
{
    public class CheckDayOfMonth : Rule, IAddInstructionRule
    {
        public CheckDayOfMonth(IAddInstructionRule next)
        {
            Next = next;
        }

        public async Task<RuleResult> Run(object model)
        {
            var ruleModel = model as AddInstructionDto;

            var isValidDayOfMonth = ruleModel.DayOfMonth >= 1 && ruleModel.DayOfMonth <= 28;

            return new RuleResult
            {
                Success = isValidDayOfMonth,
                Message = !isValidDayOfMonth ? ErrorResources.InvalidInstructionDayOfMonth : null
            };
        }
    }
}
