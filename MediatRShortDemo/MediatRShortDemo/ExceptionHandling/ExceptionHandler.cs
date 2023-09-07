using MediatR.Pipeline;

namespace MediatRShortDemo.ExceptionHandling;

public class ExceptionHandler<TRequest,TResponse, TException> : IRequestExceptionHandler<TRequest,TResponse, TException> 
    where TException : Exception
    where TResponse : new()
    where TRequest : notnull
{
    private readonly ILogger<ExceptionHandler<TRequest, TResponse, TException>> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler<TRequest,TResponse, TException>> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception thrown for {Request}", typeof(TRequest).Name);
        
        //HANDLE EXCEPTION: set the response to a default value that is not null and return a completed task
        state.SetHandled(new TResponse());
        return Task.CompletedTask;
    }
}