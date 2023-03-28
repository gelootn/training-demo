using Dapper.Demo.Dal.Infrastructure.Attributes;

namespace Dapper.Demo.Dal.Entities;

[Table("Visits")]
public class Visit : Entity
{
    public Visitor Visitor { get; init; } = null!;
    public Company Company { get; init; } = null!;
    public Employee Employee { get; init; } = null!;
    public DateTime Start { get; init; }
    public DateTime? Stop { get; set; }

}