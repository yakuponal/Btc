using Btc.Instructions.Domain.Constants;
using Btc.Instructions.Domain.Exceptions;
using Btc.Instructions.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Btc.Instructions.Api.Infrastructure.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var logLevel = LogLevel.Error;
            var statusCode = HttpStatusCode.InternalServerError;
            var responseMessage = ErrorConstants.UnexpectedError.Key;

            object args = null;
            List<ErrorResultDetail> details = null;
            string code = null;

            switch (context.Exception)
            {
                case CustomException customException:
                    {
                        if (!string.IsNullOrEmpty(customException.ResponseMessage))
                            responseMessage = customException.ResponseMessage;
                        else if (!string.IsNullOrEmpty(customException.ApiResult?.Message))
                            responseMessage = customException.ApiResult.Message;
                        else if (!string.IsNullOrEmpty(customException.ApiResult?.Code))
                            responseMessage = customException.ApiResult.Code;
                        else if (!string.IsNullOrEmpty(customException.Message))
                            responseMessage = customException.Message;

                        if (customException.Args != null)
                            args = customException.Args;

                        if (!(customException.ApiResult?.Details).IsNullOrEmpty())
                            details = customException.ApiResult!.Details.ToList();

                        if (!string.IsNullOrEmpty(customException.ApiResult?.Code))
                            code = customException.ApiResult?.Code;

                        logLevel = customException.LogLevel;
                        statusCode = customException.StatusCode;

                        break;
                    }
            }

            if (logLevel is (LogLevel.Warning or LogLevel.Error))
                _logger.Log(logLevel, responseMessage, args);

            var response = new ErrorResult
            {
                Message = responseMessage,
                Code = code,
                Details = details
            };

            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = (int)statusCode;

            context.Result = new ObjectResult(response);
        }
    }
}
