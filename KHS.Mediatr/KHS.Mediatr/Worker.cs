using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.Log(LogLevel.Information, "Worker running at: {time}", DateTimeOffset.Now);
        
        
        
        
        //throw new NotImplementedException();
        return Task.CompletedTask;
    }
}