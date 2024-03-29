﻿namespace CQRS.Vanilla.Infrastructure.Query;

public interface IQueryDispatcher
{
    Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellationToken) 
        where TQuery : IQuery<TQueryResult>;
}