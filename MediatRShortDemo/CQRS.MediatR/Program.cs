// See https://aka.ms/new-console-template for more information

using System.Reflection;
using CQRS.MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var services = GetServices();

var serviceProvider = services.BuildServiceProvider();

await serviceProvider.GetService<App>().Run();




static IServiceCollection GetServices()
{
    IServiceCollection services = new ServiceCollection();
    
    services.AddLogging(cfg => cfg.AddConsole(options => options.IncludeScopes = true));

    services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.AddTransient<App>();
    return services;
}