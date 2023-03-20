using MediatR.Demo.Dal.Entities;
using MediatR.Demo.Dal.Infrastructure.Filters;

namespace MediatR.Demo.Dal.Repositories.Interfaces;

public interface IVisitRepository : IGenericRepository<Visit>
{
    Task<Visit?> GetVisitByVisitorEmail(string email, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Visit>> GetOpenVisits(CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Visit>> GetVisits(VisitFilter filter, CancellationToken cancellationToken);

}