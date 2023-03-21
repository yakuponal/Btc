using Btc.Instructions.Application.Behaviors;
using Btc.Instructions.Application.Managers.Rule;
using Btc.Instructions.Application.Managers.Rule.Abstractions;
using Btc.Instructions.Application.Messaging.RabbitMQ;
using Btc.Instructions.Application.Messaging.RabbitMQ.Abstractions;
using Btc.Instructions.Application.Rules.Instruction.AddInstruction.Abstractions;
using Btc.Instructions.Application.Rules.Instruction.DeleteInstruction.Abstractions;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AddInstruction = Btc.Instructions.Application.Rules.Instruction.AddInstruction;
using DeleteInstruction = Btc.Instructions.Application.Rules.Instruction.DeleteInstruction;

namespace Btc.Instructions.Application.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();
        }

        public static void AddRules(this IServiceCollection services)
        {
            services.Chain<IAddInstructionRule>()
                .Add<AddInstruction.CheckDayOfMonth>()
                .Add<AddInstruction.CheckInstructionAmount>()
                .Add<AddInstruction.CheckIsUserExist>()
                .Add<AddInstruction.CheckHasInstruction>()
                .Configure();

            services.Chain<IDeleteInstructionRule>()
                .Add<DeleteInstruction.CheckIsUserExist>()
                .Add<DeleteInstruction.CheckHasInstruction>()
                .Configure();
        }

        public static void AddMappings(this IServiceCollection services)
        {
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }

        public static void AddManagers(this IServiceCollection services)
        {
            services.AddScoped<IRuleManager, RuleManager>();
        }
    }
}
