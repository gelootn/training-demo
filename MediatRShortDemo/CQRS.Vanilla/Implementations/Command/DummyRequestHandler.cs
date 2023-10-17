using CQRS.Vanilla.Infrastructure.Command;
using Microsoft.Extensions.Logging;

namespace CQRS.Vanilla.Implementations;

public class DummyRequestHandler : ICommandHandler<DummyCommand, DummyResponse>
{
    private readonly ILogger<DummyRequestHandler> _logger;

    public DummyRequestHandler(ILogger<DummyRequestHandler> logger)
    {
        _logger = logger;
    }
    public async Task<DummyResponse> Handle(DummyCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling request {Request}", command.GetType().Name);
        return new DummyResponse();
    }
}