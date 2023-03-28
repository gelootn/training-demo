using Dapper.Demo.Dal.Database;
using Dapper.Demo.Dal.Entities;
using Dapper.Demo.Dal.Repositories.Interfaces;
using System.Data;

namespace Dapper.Demo.Dal.Repositories;

public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
{
    public CompanyRepository(DapperContext context) : base(context)
    {

    }
    async Task<IReadOnlyCollection<Company>> ICompanyRepository.GetCompanies()
    {
        //return await Set.Include(x=> x.Employees).ToListAsync();
        using IDbConnection connection = Context.CreateConnection();
        var result = await connection.QueryAsync<Company>($"Select * from {TableName()}");
        return result.ToList();

    }

    async Task<Company?> ICompanyRepository.GetCompany(int id, CancellationToken cancellationToken)
    {
        using IDbConnection connection = Context.CreateConnection();
        var multiple = await connection.QueryMultipleAsync("" +
            "select * from companies where id = @Id; " +
            "select * from employees where companyId = @Id", new { Id = id });

        var company = multiple.ReadFirstOrDefault<Company>();
        var employees = multiple.Read<Employee>();
        company.Employees = employees.ToList();

        return company;
    }
}