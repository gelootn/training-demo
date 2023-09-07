namespace graphql.demo.persistence.Entities;

public abstract class Entity
{
    public int Id { get; set; }
    public bool Deleted { get; set; }
}
