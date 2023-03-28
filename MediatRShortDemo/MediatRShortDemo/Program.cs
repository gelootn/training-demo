using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace MediatRShortDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<App>().Run();

        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File("logs/mediatRDemo.log", rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .CreateLogger();

            services.AddLogging(builder => builder.AddSerilog(logger, dispose: true));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient<IMediatorService, MediatorService>();
            services.AddTransient<App>();

            return services;
        }
    }
}