namespace Btc.Instructions.Domain.Exceptions
{
    public class ErrorResult
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public IEnumerable<ErrorResultDetail> Details { get; set; }
    }
}
