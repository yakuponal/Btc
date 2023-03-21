using Btc.Instructions.Data.Abstractions;
using Btc.Instructions.Data.Repositories;
using Btc.Instructions.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Btc.Instructions.Data.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InstructionDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSql")));
            services.AddScoped<IInstructionDbContext, InstructionDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IInstructionRepository, InstructionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
