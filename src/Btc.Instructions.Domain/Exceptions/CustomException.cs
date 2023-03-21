using Microsoft.Extensions.Logging;
using System.Net;

namespace Btc.Instructions.Domain.Exceptions
{
    public class CustomException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public string ResponseMessage { get; }

        public object Args { get; }

        public LogLevel LogLevel { get; }

        public ErrorResult ApiResult { get; set; }

        public CustomException(HttpStatusCode statusCode, string errorCode = null, string responseMessage = null, object args = null, LogLevel logLevel = LogLevel.Information)
            : base(errorCode)
        {
            StatusCode = statusCode;
            ResponseMessage = responseMessage;
            Args = args;
            LogLevel = logLevel;
        }

        public CustomException(HttpStatusCode statusCode, ErrorResult errorResult, string logMessage = "", object args = null, LogLevel logLevel = LogLevel.Error) : base(logMessage)
        {
            StatusCode = statusCode;
            ApiResult = errorResult;
            Args = args;
            LogLevel = logLevel;
        }
    }
}
