namespace graphql.demo.persistence.Entities;

public class Company : Entity
{
    public string? Name { get; set; }
    public ICollection<Employee>? Employees { get; set; }
}
