using MediatR;

namespace CQRS.MediatR.Infrastructure;

interface ICommand<out TCommandResult>: IRequest<TCommandResult> { }