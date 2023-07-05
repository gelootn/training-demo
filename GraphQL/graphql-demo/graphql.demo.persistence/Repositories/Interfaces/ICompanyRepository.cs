using graphql.demo.persistence.Entities;

namespace graphql.demo.persistence.Repositories.Interfaces;

public interface ICompanyRepository : IGenericRepository<Company>
{
    Task<IReadOnlyCollection<Company>> GetCompanies();
    Task<Company?> GetCompany(int id, CancellationToken cancellationToken);
}