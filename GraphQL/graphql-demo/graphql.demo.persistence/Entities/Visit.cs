namespace graphql.demo.persistence.Entities;

public class Visit : Entity
{
    public Visitor Visitor { get; init; } = null!;
    public Company Company { get; init; } = null!;
    public Employee Employee { get; init; } = null!;
    public DateTime Start { get; init; }
    public DateTime? Stop { get; set; }

}