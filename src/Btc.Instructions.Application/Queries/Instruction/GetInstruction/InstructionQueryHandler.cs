using Btc.Instructions.Data.Repositories.Abstractions;
using Btc.Instructions.Domain.Exceptions;
using Btc.Instructions.Domain.Resources;
using Mapster;
using MediatR;
using System.Net;

namespace Btc.Instructions.Application.Queries.Instruction.GetInstruction
{
    public class InstructionQueryHandler : IRequestHandler<InstructionQuery, InstructionQueryResult>
    {
        private readonly IInstructionRepository _instructionRepository;

        public InstructionQueryHandler(IInstructionRepository instructionRepository)
        {
            _instructionRepository = instructionRepository;
        }

        public async Task<InstructionQueryResult> Handle(InstructionQuery request, CancellationToken cancellationToken)
        {
            var instruction = await _instructionRepository.GetByUserId(request.UserId, request.Include);

            if (instruction == null)
                throw new CustomException(HttpStatusCode.NotFound, responseMessage: ErrorResources.InstructionNotFound);

            return instruction.Adapt<InstructionQueryResult>();
        }
    }
}
