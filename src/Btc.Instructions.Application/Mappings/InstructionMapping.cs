using Btc.Instructions.Domain.Dtos.Instruction;
using Btc.Instructions.Domain.Enums;
using Mapster;
using Entity = Btc.Instructions.Data.Entities;

namespace Btc.Instructions.Application.Mappings
{
    public class InstructionMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<AddInstructionDto, Entity.Instruction>()
                .Map(d => d.Notifications, s => s.NotificationTypes);

            config.ForType<InstructionNotificationType, Entity.InstructionNotification>()
                .Map(d => d.Type, s => (int)s);
        }
    }
}
