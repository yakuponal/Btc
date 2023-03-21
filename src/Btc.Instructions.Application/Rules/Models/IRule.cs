namespace Btc.Instructions.Application.Rules.Models
{
    public interface IRule
    {
        Task<RuleResult> Run(object model);
        IRule Next { get; set; }
    }
}
