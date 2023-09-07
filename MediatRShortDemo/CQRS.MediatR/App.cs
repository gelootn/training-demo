using CQRS.MediatR.Command;
using CQRS.MediatR.Query;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRS.MediatR;

public class App
{
    private readonly IMediator _mediatr;
    private readonly ILogger<App> _logger;

    public App(IMediator mediatr, ILogger<App> logger)
    {
        _mediatr = mediatr;
        _logger = logger;
    }
    
    public async Task Run()
    {
        await SendDummyQuery();
        await SendDummyCommand();
    }

    private async Task SendDummyCommand()
    {
        await _mediatr.Send(new DummyCommand());
    }

    private async Task SendDummyQuery()
    {
        await _mediatr.Send(new DummyQuery());
    }
}