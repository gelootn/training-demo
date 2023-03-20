using MediatR.Demo.Dal.Entities;

namespace MediatR.Demo.Dal.Repositories.Interfaces;

public interface IVisitorRepository : IGenericRepository<Visitor>
{
    Task<Visitor?> GetVisitorByEmail(string email, CancellationToken cancellationToken);
}