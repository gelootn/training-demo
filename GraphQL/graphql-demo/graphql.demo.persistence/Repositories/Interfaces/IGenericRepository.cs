using graphql.demo.persistence.Entities;

namespace graphql.demo.persistence.Repositories.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    IQueryable<TEntity> GetAll();
    Task<TEntity> AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken);
    void Delete(TEntity? entity);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}