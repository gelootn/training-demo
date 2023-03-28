using Dapper.Demo.Dal.Entities;

namespace Dapper.Demo.Dal.Repositories.Interfaces;

public interface ICompanyRepository : IGenericRepository<Company>
{
    Task<IReadOnlyCollection<Company>> GetCompanies();
    Task<Company?> GetCompany(int id, CancellationToken cancellationToken);
}