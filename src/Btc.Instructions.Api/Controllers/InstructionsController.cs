using Btc.Instructions.Api.Models.Requests.Instruction;
using Btc.Instructions.Application.Commands.Instruction.AddInstruction;
using Btc.Instructions.Application.Commands.Instruction.DeleteInstruction;
using Btc.Instructions.Application.Queries.Instruction.GetInstruction;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Btc.Instructions.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        private readonly ISender _sender;

        public InstructionsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetInstructionRequest request)
        {
            var query = request.Adapt<InstructionQuery>();

            var instruction = await _sender.Send(query);

            return Ok(instruction);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddInstructionRequest request)
        {
            var command = request.Adapt<AddInstructionCommand>();

            await _sender.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteInstructionRequest request)
        {
            var command = request.Adapt<DeleteInstructionCommand>();

            await _sender.Send(command);

            return NoContent();
        }
    }
}
