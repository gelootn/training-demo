using MediatR;

namespace CQRS.MediatR.Infrastructure;

interface ICommandHandler<in TCommand, TCommandResult> : IRequestHandler<TCommand, TCommandResult> where TCommand : ICommand<TCommandResult> { }