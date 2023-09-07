using MediatR;

namespace CQRS.MediatR.Infrastructure;

interface IQuery<out TIQueryResult> : IRequest<TIQueryResult> { }