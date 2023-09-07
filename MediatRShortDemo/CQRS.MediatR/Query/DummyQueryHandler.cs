using CQRS.MediatR.Infrastructure;
using Microsoft.Extensions.Logging;

namespace CQRS.MediatR.Query;

public class DummyQueryHandler : IQueryHandler<DummyQuery, DummyQueryResponse>
{
    private readonly ILogger<DummyQueryHandler> _logger;

    public DummyQueryHandler(ILogger<DummyQueryHandler> logger)
    {
        _logger = logger;
    }
    
    public Task<DummyQueryResponse> Handle(DummyQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling request {Request}", request.GetType().Name);
        return Task.FromResult(new DummyQueryResponse());
    }
}