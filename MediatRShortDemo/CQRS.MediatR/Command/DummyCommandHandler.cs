using CQRS.MediatR.Infrastructure;
using Microsoft.Extensions.Logging;

namespace CQRS.MediatR.Command;

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