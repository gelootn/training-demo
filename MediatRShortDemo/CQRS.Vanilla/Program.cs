// See https://aka.ms/new-console-template for more information

using CQRS.Vanilla;
using CQRS.Vanilla.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello, World!");

var services = GetServices();

var serviceProvider = services.BuildServiceProvider();

await serviceProvider.GetService<MyApp>().Run();

static IServiceCollection GetServices()
{
    IServiceCollection services = new ServiceCollection();
    
    services.AddLogging(cfg => cfg.AddConsole(options => options.IncludeScopes = true));
    services.RegisterCqrs();
    
    
    services.AddTransient<MyApp>();
    return services;
}

