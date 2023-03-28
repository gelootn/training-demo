using Dapper.Demo.Dal.Infrastructure.Attributes;

namespace Dapper.Demo.Dal.Entities;

[Table("Companies")]
public class Company : Entity
{
    public string? Name { get; set; }
    public ICollection<Employee>? Employees { get; set; }
}
