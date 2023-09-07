namespace CQRS.Vanilla.Infrastructure.Command;

public interface ICommandDispatcher
{
    Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellationToken);
}