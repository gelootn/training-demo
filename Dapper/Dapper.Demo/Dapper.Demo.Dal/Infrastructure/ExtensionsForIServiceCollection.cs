using Dapper.Demo.Dal.Database;
using Dapper.Demo.Dal.Repositories;
using Dapper.Demo.Dal.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dapper.Demo.Dal.Infrastructure;

public static class ExtensionsForIServiceCollection
{
    public static void AddDataLayer(this IServiceCollection services, string connectionString)
    {
        //TODO: ADD DAPPER
        services.AddSingleton(x=> new DapperContext(connectionString));
        //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddScoped<IVisitorRepository, VisitorRepository>();
    }
}