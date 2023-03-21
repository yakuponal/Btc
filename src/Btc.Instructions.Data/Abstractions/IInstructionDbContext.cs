using Btc.Instructions.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Btc.Instructions.Data.Abstractions
{
    public interface IInstructionDbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Instruction> Instruction { get; set; }
        public DbSet<InstructionNotification> InstructionNotification { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
