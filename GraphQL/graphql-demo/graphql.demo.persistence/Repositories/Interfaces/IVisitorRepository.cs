using graphql.demo.persistence.Entities;

namespace graphql.demo.persistence.Repositories.Interfaces;

public interface IVisitorRepository : IGenericRepository<Visitor>
{
    Task<Visitor?> GetVisitorByEmail(string email, CancellationToken cancellationToken);
}