using Btc.Instructions.Application.Rules.Instruction.AddInstruction.Abstractions;
using Btc.Instructions.Application.Rules.Models;
using Btc.Instructions.Data.Repositories.Abstractions;
using Btc.Instructions.Domain.Dtos.Instruction;
using Btc.Instructions.Domain.Resources;

namespace Btc.Instructions.Application.Rules.Instruction.AddInstruction
{
    public class CheckHasInstruction : Rule, IAddInstructionRule
    {
        private readonly IInstructionRepository _instructionRepository;

        public CheckHasInstruction(IAddInstructionRule next, IInstructionRepository instructionRepository)
        {
            _instructionRepository = instructionRepository;

            Next = next;
        }

        public async Task<RuleResult> Run(object model)
        {
            var ruleModel = model as AddInstructionDto;

            var isExist = await _instructionRepository.IsExistByUserId(ruleModel.UserId);

            return new RuleResult
            {
                Success = !isExist,
                Message = isExist ? ErrorResources.HasInstruction : null
            };
        }
    }
}
