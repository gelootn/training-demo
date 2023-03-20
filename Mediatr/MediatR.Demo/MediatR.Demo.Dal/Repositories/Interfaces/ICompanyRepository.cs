using MediatR.Demo.Dal.Entities;

namespace MediatR.Demo.Dal.Repositories.Interfaces;

public interface ICompanyRepository : IGenericRepository<Company>
{
    Task<IReadOnlyCollection<Company>> GetCompanies();
    Task<Company?> GetCompany(int id, CancellationToken cancellationToken);
}