using graphql.demo.persistence.Database;
using graphql.demo.persistence.Repositories;
using graphql.demo.persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace graphql.demo.persistence.Infrastructure;

public static class ExtensionsForIServiceCollection
{
    public static void AddDataLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DemoDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        }, ServiceLifetime.Scoped);

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddScoped<IVisitorRepository, VisitorRepository>();
    }
}