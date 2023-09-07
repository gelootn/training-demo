namespace CQRS.Vanilla.Infrastructure.Query;

public interface IQueryHandler<in TQuery, TQueryResult> 
{
    Task<TQueryResult> Handle(TQuery query, CancellationToken cancellationToken);
}