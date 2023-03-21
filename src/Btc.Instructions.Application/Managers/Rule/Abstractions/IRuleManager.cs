using Btc.Instructions.Application.Rules.Models;

namespace Btc.Instructions.Application.Managers.Rule.Abstractions
{
    public interface IRuleManager
    {
        Task OperateRules(IRule rule, object model);
    }
}
