namespace graphql.demo.persistence.Entities;

public class Employee : Entity
{
    public string? Name { get; init; }  
    public string? Email { get; init; }
    public string? Function { get; set; }
    public int CompanyId { get; init; }
    public Company? Company { get; init; }
}
