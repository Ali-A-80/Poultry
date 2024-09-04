using FluentValidation;
using MediatR;

namespace Poultry.Application.Core;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults.SelectMany(result => result.Errors)
                                        .Where(f => f != null)
                                        .Select(f => f.ErrorMessage)
                                        .ToList();

        if (failures.Count != 0)
        {
            return CreateValidationResult<TResponse>(failures);
        }

        return await next();
    }

    private static TResponse CreateValidationResult<TResponse>(List<string> errors)
    {
        var responseType = typeof(TResponse);
        var failureMethod = responseType.GetMethod(nameof(ResultDto<object>.Failure), new[] { typeof(List<string>) });
        return (TResponse)failureMethod.Invoke(null, new object[] { errors });
    }
}

