using Dapper.Demo.Dal.Entities;
using Dapper.Demo.Dal.Infrastructure.Filters;

namespace Dapper.Demo.Dal.Repositories.Interfaces;

public interface IVisitRepository : IGenericRepository<Visit>
{
    Task<Visit?> GetVisitByVisitorEmail(string email, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Visit>> GetOpenVisits(CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Visit>> GetVisits(VisitFilter filter, CancellationToken cancellationToken);

}