using MediatR.Demo.Dal.Database;
using MediatR.Demo.Dal.Entities;
using MediatR.Demo.Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediatR.Demo.Dal.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(DemoDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyCollection<Employee>> GetEmployeesForCompany(int companyId, CancellationToken cancellationToken)
    {
        var employees = await Set.Where(x => x.CompanyId == companyId).ToListAsync(cancellationToken: cancellationToken);
        return employees;
    }

    public async Task<Employee?> GetEmployee(int id, CancellationToken cancellationToken)
    {
        var employee = await Set.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return employee;
    }
}