using Btc.Instructions.Domain.Constants;
using Btc.Instructions.Domain.Exceptions;
using Btc.Instructions.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Btc.Instructions.Api.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        private readonly ILogger<ValidationFilter> _logger;

        public ValidationFilter(ILogger<ValidationFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                await next();
                return;
            }

            var modelState = context.ModelState.Where(x => !string.IsNullOrEmpty(x.Key) && !(x.Value?.Errors).IsNullOrEmpty()).ToList();

            var errors = modelState
                .Select(x =>
                {
                    var (key, value) = x;

                    var errorResultDetail = new ErrorResultDetail { Field = key };

                    errorResultDetail.Message = value.Errors.Select(y => y.ErrorMessage);

                    return errorResultDetail;
                })
                .ToList();

            var errorResult = new ErrorResult
            {
                Message = ErrorConstants.ValidationError.Key,
                Code = ErrorConstants.ValidationError.Value,
                Details = errors
            };

            var logValues = new Dictionary<string, object>
            {
                { nameof(ErrorResult.Message), errorResult.Message },
                { nameof(ErrorResult.Details), modelState.ToDictionary(x => x.Key, x => x.Value!.Errors.Select(y => y.ErrorMessage)) }
            };

            _logger.LogWarning("{logValues}", logValues);

            context.Result = new BadRequestObjectResult(errorResult);
        }
    }

}
