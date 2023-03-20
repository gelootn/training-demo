using MediatR.Demo.Dal.Entities;

namespace MediatR.Demo.Dal.Repositories.Interfaces;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<IReadOnlyCollection<Employee>> GetEmployeesForCompany(int companyId, CancellationToken cancellationToken);
    Task<Employee?> GetEmployee(int id, CancellationToken cancellationToken);
}