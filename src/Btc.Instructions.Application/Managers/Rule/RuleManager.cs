using Btc.Instructions.Application.Managers.Rule.Abstractions;
using Btc.Instructions.Application.Rules.Models;
using Btc.Instructions.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Btc.Instructions.Application.Managers.Rule
{
    public class RuleManager : IRuleManager
    {
        public async Task OperateRules(IRule rule, object model)
        {
            bool hasNext;
            do
            {
                hasNext = rule.Next != null;

                var ruleResult = await rule.Run(model);
                if (ruleResult.Success)
                    rule = rule.Next;
                else
                    throw new CustomException(HttpStatusCode.BadRequest, responseMessage: ruleResult.Message, logLevel: LogLevel.Warning);
            } while (hasNext);
        }
    }
}
