using graphql.demo.persistence.Database;
using graphql.demo.persistence.Entities;
using graphql.demo.persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace graphql.demo.persistence.Repositories;

public  class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
{
    private readonly DemoDbContext _context;
    protected readonly DbSet<TEntity> Set;

    public GenericRepository(DemoDbContext context)
    {
        _context = context;
        Set = context.Set<TEntity>();
    }


    IQueryable<TEntity> IGenericRepository<TEntity>.GetAll()
    {
        return Set;
    }

    async Task<TEntity> IGenericRepository<TEntity>.AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        if (entity.Id == 0)
        {
           await Set.AddAsync(entity, cancellationToken);
        }
        else
        {
            Set.Update(entity);
        }

        return entity;
    }

    void IGenericRepository<TEntity>.Delete(TEntity? entity)
    {
        SetDeleted(entity);
    }

    async Task IGenericRepository<TEntity>.DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await Set.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
        SetDeleted(entity);
    }

    async Task IGenericRepository<TEntity>.SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    private void SetDeleted(TEntity? entity)
    {
        if (entity != null)
        {
            entity.Deleted = true;
        }
    }
}