using Btc.Instructions.Data.Abstractions;
using Btc.Instructions.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Btc.Instructions.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IInstructionDbContext _instructionDbContext;

        public UserRepository(IInstructionDbContext instructionDbContext)
        {
            _instructionDbContext = instructionDbContext;
        }

        public async Task<bool> IsExist(int id)
        {
            return await _instructionDbContext.User.AnyAsync(x => x.Id == id);
        }
    }
}
