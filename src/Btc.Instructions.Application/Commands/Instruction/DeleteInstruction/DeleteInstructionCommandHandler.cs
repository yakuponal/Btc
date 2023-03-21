using Btc.Instructions.Application.Managers.Rule.Abstractions;
using Btc.Instructions.Application.Rules.Instruction.DeleteInstruction.Abstractions;
using Btc.Instructions.Data.Repositories.Abstractions;
using MediatR;

namespace Btc.Instructions.Application.Commands.Instruction.DeleteInstruction
{
    public class DeleteInstructionCommandHandler : IRequestHandler<DeleteInstructionCommand, Unit>
    {
        private readonly IRuleManager _ruleManager;
        private readonly IDeleteInstructionRule _rule;
        private readonly IInstructionRepository _instructionRepository;

        public DeleteInstructionCommandHandler(
            IRuleManager ruleManager,
            IDeleteInstructionRule rule,
            IInstructionRepository instructionRepository)
        {
            _ruleManager = ruleManager;
            _rule = rule;
            _instructionRepository = instructionRepository;
        }

        public async Task<Unit> Handle(DeleteInstructionCommand request, CancellationToken cancellationToken)
        {
            await _ruleManager.OperateRules(_rule, request);
            await _instructionRepository.UpdateInstructionPassive(request.InstructionId);

            return Unit.Value;
        }
    }
}
