
# CQRS in C# without MediatR
CQRS does not imply the use of MediatR. This is a simple example of how to implement CQRS in C# without MediatR. There is some extra infrastructure code so that the separation between commands and queries is clear.

# Infrastructure code
## Command
A Command is defined by the `ICommand<TResult>` interface. 

The command Handler is defined by the `ICommandHandler<TCommand, TResult>` interface. 

The `CommandHandler` class is an abstract class that implements the `ICommandHandler<TCommand, TResult>` interface. The `CommandHandler` class has a `Handle` method that is called by the `CommandDispatcher` class. The `CommandDispatcher` class is responsible for dispatching the command to the correct command handler. The `CommandDispatcher` class is a singleton.