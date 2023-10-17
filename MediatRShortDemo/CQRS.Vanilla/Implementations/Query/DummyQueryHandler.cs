using CQRS.Vanilla.Infrastructure.Query;

namespace CQRS.Vanilla.Implementations.Query;

public class DummyQueryHandler : IQueryHandler<DummyQuery, DummyQueryResult>
{
    public async Task<DummyQueryResult> Handle(DummyQuery query, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new DummyQueryResult());
    }
}