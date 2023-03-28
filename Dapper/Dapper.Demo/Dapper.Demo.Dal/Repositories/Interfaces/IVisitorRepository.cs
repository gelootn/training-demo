using Dapper.Demo.Dal.Entities;

namespace Dapper.Demo.Dal.Repositories.Interfaces;

public interface IVisitorRepository : IGenericRepository<Visitor>
{
    Task<Visitor?> GetVisitorByEmail(string email, CancellationToken cancellationToken);
}