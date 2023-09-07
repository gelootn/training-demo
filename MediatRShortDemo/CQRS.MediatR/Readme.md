# CQRS in C# with MediatR
This is a simple example of how to implement CQRS in C# using MediatR. There is some extra infrastructure code so that the separation between commands and queries is clear.
The extra infrastructure code is not necessary, but it helps to understand the separation between commands and queries. 

## Packages
Packages used in this example:
- MediatR
- MediatR.Extensions.Microsoft.DependencyInjection
- Microsoft.Extensions.DependencyInjection
- Microsoft.Extensions.Logging
- Microsoft.Extensions.Logging.Console

## Extra infrastructure code
### Command
The `ICommand` is a simple interface that implements the `IRequest` interface. The `IRequest` interface is defined in the MediatR library. 
```csharp
interface ICommand<out TCommandResult>: IRequest<TCommandResult> { }
```
The `ICommandHandler` is a simple interface that implements the `IRequestHandler` interface. The `IRequestHandler` interface is defined in the MediatR library. 
```csharp
interface ICommandHandler<in TICommand, TICommandResult> : IRequestHandler<TICommand, TICommandResult> where TICommand : ICommand<TICommandResult> { }
```

### Query
The `IQuery` is a simple interface that implements the `IRequest` interface. The `IRequest` interface is defined in the MediatR library. 
```csharp
interface IQuery<out TIQueryResult> : IRequest<TIQueryResult> { }
```
The `IQueryHandler` is a simple interface that implements the `IRequestHandler` interface. The `IRequestHandler` interface is defined in the MediatR library. 
```csharp
interface IQueryHandler<in TIQuery, TIQueryResult> : IRequestHandler<TIQuery, TIQueryResult> where TIQuery : IQuery<TIQueryResult> { }
```

## Implementation
With the use of the extra infrastructure code, the implementation of the commands and queries is very simple.
both commands and queries use there own interface and handler. The implementation of the handler is the same as the implementation of the MediatR handler.

### Example command

A command inherits from the `ICommand` interface. The `ICommand` interface is defined in the extra infrastructure code. 
```csharp
public class DummyCommand : ICommand<DummyCommandResult>
{ 
    /// Command properties
}
```
The command handler inherits from the `ICommandHandler` interface. The `ICommandHandler` interface is defined in the extra infrastructure code. 
```csharp
public class DummyCommandHandler : ICommandHandler<DummyCommand, DummyCommandResult>
{
    private readonly ILogger<DummyCommandHandler> _logger;

    public DummyCommandHandler(ILogger<DummyCommandHandler> logger)
    {
        _logger = logger;
    }

    public Task<DummyCommandResult> Handle(DummyCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling request {Request}", request.GetType().Name);
        return Task.FromResult(new DummyCommandResult());
    }
}
```
The execution remains the same, create a new command and use de `send` method of the `IMediator` interface. The `IMediator` interface is defined in the MediatR library. 
```csharp
private async Task SendDummyCommand()
{
    var result = await _mediatr.Send(new DummyCommand());
    /// Do something with the result
}    
```


