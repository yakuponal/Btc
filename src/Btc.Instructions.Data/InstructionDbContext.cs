using Btc.Instructions.Data.Abstractions;
using Btc.Instructions.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Btc.Instructions.Data
{
    public class InstructionDbContext : DbContext, IInstructionDbContext
    {
        protected readonly IConfiguration _configuration;

        public InstructionDbContext(IConfiguration configuration, DbContextOptions options)
                : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Instruction> Instruction { get; set; }
        public DbSet<InstructionNotification> InstructionNotification { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgreSql"));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) => base.SaveChangesAsync(cancellationToken);
    }
}
