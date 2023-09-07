using MediatR.Pipeline;

namespace MediatRShortDemo.ExceptionHandling;

public class ExceptionAction<TRequest, TException> : IRequestExceptionAction<TRequest, TException> 
    where TException : Exception
{
    private readonly ILogger<ExceptionAction<TRequest, TException>> _logger;

    public ExceptionAction(ILogger<ExceptionAction<TRequest, TException>> logger){
        _logger = logger;
    }
    
    public Task Execute(TRequest request, TException exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception thrown for {Request}", typeof(TRequest).Name);
        return Task.CompletedTask;
    }
}