using Btc.Instructions.Data.Entities;
using Btc.Instructions.Domain.Enums;

namespace Btc.Instructions.Data.Repositories.Abstractions
{
    public interface IInstructionRepository
    {
        Task<Instruction> GetByUserId(int userId, InstructionIncludeType include);
        Task<bool> IsExist(int id);
        Task<bool> IsExistByUserId(int userId);
        Task<bool> IsExistByUserId(int id, int userId);
        Task InsertInstruction(Instruction instruction);
        Task UpdateInstructionPassive(int id);
    }
}
