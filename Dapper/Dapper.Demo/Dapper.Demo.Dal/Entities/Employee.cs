using Dapper.Demo.Dal.Infrastructure.Attributes;

namespace Dapper.Demo.Dal.Entities;

[Table("Employees")]
public class Employee : Entity
{
    public string? Name { get; init; }  
    public string? Email { get; init; }
    public string? Function { get; set; }
    public int CompanyId { get; init; }
    public Company? Company { get; init; }
}
