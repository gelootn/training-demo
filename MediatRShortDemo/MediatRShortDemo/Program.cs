
using System.Reflection;
using MediatR.Pipeline;
using MediatRShortDemo.Behaviors;
using MediatRShortDemo.ExceptionHandling;

namespace MediatRShortDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetService<App>().Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();


            services.AddLogging(cfg => cfg.AddConsole(options => options.IncludeScopes = true));

            services.AddMediatR(cfg => 
                    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                        .AddOpenBehavior(typeof(LoggingBehavior<,>)));
            services.AddTransient(typeof(IRequestExceptionAction<,>), typeof(ExceptionAction<,>));
            
            //services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(ExceptionHandler<,,>));
            services.AddTransient<IMediatorService, MediatorService>();
            services.AddTransient<App>();

            return services;
        }
    }
}