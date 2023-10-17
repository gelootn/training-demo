using CQRS.Vanilla.Implementations;
using CQRS.Vanilla.Implementations.Query;
using CQRS.Vanilla.Infrastructure.Command;
using CQRS.Vanilla.Infrastructure.Query;
using Microsoft.Extensions.Logging;

namespace CQRS.Vanilla;

public class MyApp
{
    private readonly ICommandDispatcher _commander;
    private readonly IQueryDispatcher _reader;

    private readonly ILogger<MyApp> _logger;

    public MyApp(ICommandDispatcher commander, IQueryDispatcher reader, ILogger<MyApp> logger)
    {
        _commander = commander;
        _reader = reader;
        _logger = logger;
    }
    public async Task Run(CancellationToken cancellationToken = default)
    {
       var result = await _commander.Dispatch<DummyCommand, DummyResponse>(new DummyCommand(), cancellationToken);
       
       var queryResult = await _reader.Dispatch<DummyQuery, DummyQueryResult>(new DummyQuery(), cancellationToken);
       
    }
}