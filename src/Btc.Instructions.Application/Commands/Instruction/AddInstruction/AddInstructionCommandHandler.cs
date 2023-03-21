using Btc.Instructions.Application.Managers.Rule.Abstractions;
using Btc.Instructions.Application.Messaging.RabbitMQ.Abstractions;
using Btc.Instructions.Application.Rules.Instruction.AddInstruction.Abstractions;
using Btc.Instructions.Data.Repositories.Abstractions;
using Btc.Instructions.Domain.Models;
using Btc.Instructions.Domain.Resources;
using Mapster;
using MediatR;
using Entity = Btc.Instructions.Data.Entities;

namespace Btc.Instructions.Application.Commands.Instruction.AddInstruction
{
    public class AddInstructionCommandHandler : IRequestHandler<AddInstructionCommand, Unit>
    {
        private readonly IRuleManager _ruleManager;
        private readonly IAddInstructionRule _rule;
        private readonly IInstructionRepository _instructionRepository;
        private readonly IRabbitMQProducer _rabbitMQProducer;

        public AddInstructionCommandHandler(
            IRuleManager ruleManager,
            IAddInstructionRule rule,
            IInstructionRepository instructionRepository,
            IRabbitMQProducer rabbitMQProducer)
        {
            _ruleManager = ruleManager;
            _rule = rule;
            _instructionRepository = instructionRepository;
            _rabbitMQProducer = rabbitMQProducer;
        }

        public async Task<Unit> Handle(AddInstructionCommand request, CancellationToken cancellationToken)
        {
            await _ruleManager.OperateRules(_rule, request);
            var instruction = request.Adapt<Entity.Instruction>();
            await _instructionRepository.InsertInstruction(instruction);

            request.NotificationTypes.ForEach(x => _rabbitMQProducer.SendInstructionMessage(new NotificationMessage
            {
                UserId = instruction.UserId,
                InstructionId = instruction.Id,
                TransactionDate = DateTime.Now,
                Message = string.Format(GeneralResources.Notification, instruction.UserId)
            }, x));

            return Unit.Value;
        }
    }
}
