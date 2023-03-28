using Dapper.Demo.Dal.Database;
using Dapper.Demo.Dal.Entities;
using Dapper.Demo.Dal.Repositories.Interfaces;


namespace Dapper.Demo.Dal.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(DapperContext context) : base(context)
    {
    }

    public async Task<IReadOnlyCollection<Employee>> GetEmployeesForCompany(int companyId, CancellationToken cancellationToken)
    {
        //var employees = await Set.Where(x => x.CompanyId == companyId).ToListAsync(cancellationToken: cancellationToken);
        //return employees;
        throw new NotImplementedException();
    }

    public async Task<Employee?> GetEmployee(int id, CancellationToken cancellationToken)
    {
        //var employee = await Set.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        //return employee;
        throw new NotImplementedException();
    }
}