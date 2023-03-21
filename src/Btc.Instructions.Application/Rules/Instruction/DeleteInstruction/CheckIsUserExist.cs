using Btc.Instructions.Application.Rules.Instruction.AddInstruction.Abstractions;
using Btc.Instructions.Application.Rules.Instruction.DeleteInstruction.Abstractions;
using Btc.Instructions.Application.Rules.Models;
using Btc.Instructions.Data.Repositories.Abstractions;
using Btc.Instructions.Domain.Dtos.Instruction;
using Btc.Instructions.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btc.Instructions.Application.Rules.Instruction.DeleteInstruction
{
    public class CheckIsUserExist : Rule, IDeleteInstructionRule
    {
        private readonly IUserRepository _userRepository;

        public CheckIsUserExist(IDeleteInstructionRule next, IUserRepository userRepository)
        {
            _userRepository = userRepository;

            Next = next;
        }

        public async Task<RuleResult> Run(object model)
        {
            var ruleModel = model as DeleteInstructionDto;

            var isExist = await _userRepository.IsExist(ruleModel.UserId);

            return new RuleResult
            {
                Success = isExist,
                Message = !isExist ? ErrorResources.IsUserExist : null
            };
        }
    }
}
