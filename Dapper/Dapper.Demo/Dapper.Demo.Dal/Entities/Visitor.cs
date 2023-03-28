using Dapper.Demo.Dal.Infrastructure.Attributes;

namespace Dapper.Demo.Dal.Entities;

[Table("Visitors")]
public class Visitor : Entity
{
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? Company { get; init; }

}

