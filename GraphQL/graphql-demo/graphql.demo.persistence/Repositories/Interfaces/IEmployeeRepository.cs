using graphql.demo.persistence.Entities;

namespace graphql.demo.persistence.Repositories.Interfaces;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<IReadOnlyCollection<Employee>> GetEmployeesForCompany(int companyId, CancellationToken cancellationToken);
    Task<Employee?> GetEmployee(int id, CancellationToken cancellationToken);
}