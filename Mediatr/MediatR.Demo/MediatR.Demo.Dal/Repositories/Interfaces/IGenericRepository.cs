using MediatR.Demo.Dal.Entities;

namespace MediatR.Demo.Dal.Repositories.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken);
    void Delete(TEntity? entity);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}