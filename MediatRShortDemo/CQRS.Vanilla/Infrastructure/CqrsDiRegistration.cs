using CQRS.Vanilla.Infrastructure.Command;
using CQRS.Vanilla.Infrastructure.Query;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CQRS.Vanilla.Infrastructure;

public static class CqrsDiRegistration
{
    public static void RegisterCqrs(this IServiceCollection services)
    {
        services.TryAddSingleton<ICommandDispatcher, CommandDispatcher>();
        services.TryAddSingleton<IQueryDispatcher, QueryDispatcher>();
      
        // INFO: Using https://www.nuget.org/packages/Scrutor for registering all Query and Command handlers by convention
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter =>
                {
                    filter.AssignableTo(typeof(IQueryHandler<,>));
                })
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
        });
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter =>
                {
                    filter.AssignableTo(typeof(ICommandHandler<,>));
                })
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
        });
    }
}