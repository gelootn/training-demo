using MediatR;

namespace CQRS.MediatR.Infrastructure;

interface IQueryHandler<in TQuery, TQueryResult> : IRequestHandler<TQuery, TQueryResult> 
    where TQuery : IQuery<TQueryResult> { }