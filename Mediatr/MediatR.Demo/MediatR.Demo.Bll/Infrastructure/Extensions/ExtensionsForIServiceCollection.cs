using System.Reflection;
using FluentValidation;
using MediatR.Demo.Bll.Infrastructure.Behaviors;
using MediatR.Demo.Bll.Infrastructure.Mapping;
using MediatR.Demo.Dal.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace MediatR.Demo.Bll.Infrastructure.Extensions;

public static class ExtensionsForIServiceCollection
{
    public static void AddBusinessLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDataLayer(connectionString);
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile(typeof(CompanyMap));
            cfg.AddProfile(typeof(EmployeeMap));
            cfg.AddProfile(typeof(VisitMap));
        } );
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(ValidationBehavior<,>))));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}