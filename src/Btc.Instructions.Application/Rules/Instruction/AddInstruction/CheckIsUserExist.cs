using Btc.Instructions.Application.Rules.Instruction.AddInstruction.Abstractions;
using Btc.Instructions.Application.Rules.Models;
using Btc.Instructions.Data.Repositories.Abstractions;
using Btc.Instructions.Domain.Dtos.Instruction;
using Btc.Instructions.Domain.Resources;

namespace Btc.Instructions.Application.Rules.Instruction.AddInstruction
{
    public class CheckIsUserExist : Rule, IAddInstructionRule
    {
        private readonly IUserRepository _userRepository;

        public CheckIsUserExist(IAddInstructionRule next, IUserRepository userRepository)
        {
            _userRepository = userRepository;

            Next = next;
        }

        public async Task<RuleResult> Run(object model)
        {
            var ruleModel = model as AddInstructionDto;

            var isExist = await _userRepository.IsExist(ruleModel.UserId);

            return new RuleResult
            {
                Success = isExist,
                Message = !isExist ? ErrorResources.IsUserExist : null
            };
        }
    }
}
