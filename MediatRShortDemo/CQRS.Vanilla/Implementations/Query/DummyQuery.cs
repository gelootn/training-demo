using CQRS.Vanilla.Infrastructure.Query;

namespace CQRS.Vanilla.Implementations.Query;

public class DummyQuery : IQuery<DummyQueryResult>
{
    public string Filter1 { get; set; }
    public string Filter2 { get; set; }
}