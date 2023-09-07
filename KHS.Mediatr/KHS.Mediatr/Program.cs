

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddLogging(cfg => cfg.AddConsole());
    })
    .Build();
    
   await host.StartAsync();