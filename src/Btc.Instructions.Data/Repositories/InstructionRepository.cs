using Btc.Instructions.Data.Abstractions;
using Btc.Instructions.Data.Entities;
using Btc.Instructions.Data.Repositories.Abstractions;
using Btc.Instructions.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Btc.Instructions.Data.Repositories
{
    public class InstructionRepository : IInstructionRepository
    {
        private readonly IInstructionDbContext _instructionDbContext;

        public InstructionRepository(IInstructionDbContext instructionDbContext)
        {
            _instructionDbContext = instructionDbContext;
        }

        public async Task<Instruction> GetByUserId(int userId, InstructionIncludeType include)
        {
            IQueryable<Instruction> instruction = _instructionDbContext.Instruction;

            if (include == InstructionIncludeType.Notifications)
                instruction = instruction.Include(x => x.Notifications.Where(x => x.IsActive));

            return await instruction.FirstOrDefaultAsync(x => x.UserId == userId && x.IsActive);
        }

        public async Task<bool> IsExist(int id)
        {
            return await _instructionDbContext.Instruction.AnyAsync(x => x.Id == id && x.IsActive);
        }

        public async Task<bool> IsExistByUserId(int userId)
        {
            return await _instructionDbContext.Instruction.AnyAsync(x => x.UserId == userId && x.IsActive);
        }

        public async Task<bool> IsExistByUserId(int id, int userId)
        {
            return await _instructionDbContext.Instruction.AnyAsync(x => x.Id == id && x.UserId == userId && x.IsActive);
        }

        public async Task InsertInstruction(Instruction instruction)
        {
            instruction.IsActive = true;
            instruction.Notifications?.ForEach(x => x.IsActive = true);

            await _instructionDbContext.Instruction.AddAsync(instruction);
            await _instructionDbContext.SaveChangesAsync();
        }

        public async Task UpdateInstructionPassive(int id)
        {
            var instruction = await _instructionDbContext.Instruction.Include(x => x.Notifications).FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (instruction != null)
            {
                instruction.IsActive = false;
                instruction.Notifications?.ForEach(x => x.IsActive = false);

                await _instructionDbContext.SaveChangesAsync();
            }
        }
    }
}
