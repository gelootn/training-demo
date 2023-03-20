
using FluentValidation;
using MediatR.Demo.Bll.Infrastructure.Extensions;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Infrastructure.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IValidatable
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) 
            return await next();

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults.SelectMany(vr => vr.GetErrorMessages());

        if (!failures.Any()) 
            return await next();

        var resultType = typeof(TResponse).GetGenericArguments()[0];
        var failedValidationResponseType = typeof(Response<>).MakeGenericType(resultType);
        var invalidResponse = Activator.CreateInstance(failedValidationResponseType,
            failures) as TResponse;

        return invalidResponse;

    }
}