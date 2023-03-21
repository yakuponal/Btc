using Btc.Instructions.Application.Rules.Instruction.DeleteInstruction.Abstractions;
using Btc.Instructions.Application.Rules.Models;
using Btc.Instructions.Data.Repositories.Abstractions;
using Btc.Instructions.Domain.Dtos.Instruction;
using Btc.Instructions.Domain.Resources;

namespace Btc.Instructions.Application.Rules.Instruction.DeleteInstruction
{
    public class CheckHasInstruction : Rule, IDeleteInstructionRule
    {
        private readonly IInstructionRepository _instructionRepository;

        public CheckHasInstruction(IDeleteInstructionRule next, IInstructionRepository instructionRepository)
        {
            _instructionRepository = instructionRepository;

            Next = next;
        }

        public async Task<RuleResult> Run(object model)
        {
            var ruleModel = model as DeleteInstructionDto;

            var isExist = await _instructionRepository.IsExistByUserId(ruleModel.InstructionId, ruleModel.UserId);

            return new RuleResult
            {
                Success = isExist,
                Message = !isExist ? ErrorResources.HasNoInstruction : null
            };
        }
    }
}
