
using Dapper.Demo.Dal.Database;
using Dapper.Demo.Dal.Entities;
using Dapper.Demo.Dal.Infrastructure.Attributes;
using Dapper.Demo.Dal.Repositories.Interfaces;


namespace Dapper.Demo.Dal.Repositories;

public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
{
    protected readonly DapperContext Context;

    public GenericRepository(DapperContext context)
    {
        Context = context;
    }
    
    async Task<TEntity> IGenericRepository<TEntity>.AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        if (entity.Id == 0)
        {
           //await Set.AddAsync(entity, cancellationToken);
        }
        else
        {
            //Set.Update(entity);
        }

        return entity;
    }

    void IGenericRepository<TEntity>.Delete(TEntity? entity)
    {
        SetDeleted(entity);
    }

    async Task IGenericRepository<TEntity>.DeleteAsync(int id, CancellationToken cancellationToken)
    {
        //var entity = await Set.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
        //SetDeleted(entity);
    }

    async Task IGenericRepository<TEntity>.SaveChangesAsync(CancellationToken cancellationToken)
    {
        //await _context.SaveChangesAsync(cancellationToken);
    }

    protected string? TableName()
    {
        var tableAttribute = typeof(TEntity).GetCustomAttributes(typeof(TableAttribute), true).Cast<TableAttribute>().FirstOrDefault();
        if(tableAttribute !=null) return tableAttribute.TableName;
        return null;
    }

    private void SetDeleted(TEntity? entity)
    {
        if (entity != null)
        {
            entity.Deleted = true;
        }
    }
}