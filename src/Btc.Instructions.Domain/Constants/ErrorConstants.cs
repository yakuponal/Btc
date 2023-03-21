namespace Btc.Instructions.Domain.Constants
{
    public static class ErrorConstants
    {
        public static KeyValuePair<string, string> ValidationError = new("validation.error", "1000");
        public static KeyValuePair<string, string> UnexpectedError = new("unexpected.error", "1001");
    }
}
