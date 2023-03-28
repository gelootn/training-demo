using System.Reflection;
using Dapper.Demo.Bll.Infrastructure.Behaviors;
using Dapper.Demo.Bll.Infrastructure.Mapping;
using Dapper.Demo.Dal.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Dapper.Demo.Bll.Infrastructure.Extensions;

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