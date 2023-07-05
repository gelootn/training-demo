using graphql.demo.persistence.Entities;
using graphql.demo.persistence.Infrastructure.Filters;

namespace graphql.demo.persistence.Repositories.Interfaces;

public interface IVisitRepository : IGenericRepository<Visit>
{
    Task<Visit?> GetVisitByVisitorEmail(string email, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Visit>> GetOpenVisits(CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Visit>> GetVisits(VisitFilter filter, CancellationToken cancellationToken);

}