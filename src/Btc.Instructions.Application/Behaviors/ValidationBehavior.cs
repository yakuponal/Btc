using Btc.Instructions.Domain.Constants;
using Btc.Instructions.Domain.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Btc.Instructions.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);
            List<ValidationFailure> source = (from f in (await Task.WhenAll(_validators.Select((v) => v.ValidateAsync(context, cancellationToken)))).SelectMany((r) => r.Errors)
                                              where f != null
                                              select f).ToList();
            if (!source.Any())
            {
                return await next();
            }

            List<ErrorResultDetail> details = (from x in (from x in source
                                                          group x by x.PropertyName).ToList()
                                               select new ErrorResultDetail
                                               {
                                                   Field = x.Key,
                                                   Message = x.Select((y) => y.ErrorMessage)
                                               }).ToList();

            var error = new ErrorResult
            {
                Message = ErrorConstants.ValidationError.Key,
                Code = ErrorConstants.ValidationError.Value,
                Details = details
            };

            throw new CustomException(HttpStatusCode.BadRequest, error, logLevel: LogLevel.Warning);
        }
    }
}
