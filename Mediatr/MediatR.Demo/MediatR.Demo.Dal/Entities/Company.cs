namespace MediatR.Demo.Dal.Entities;

public class Company : Entity
{
    public string? Name { get; set; }
    public ICollection<Employee>? Employees { get; set; }
}
