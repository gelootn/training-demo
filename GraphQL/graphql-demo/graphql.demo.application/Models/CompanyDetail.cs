namespace graphql.demo.application.Models;

public class CompanyDetail
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<EmployeeDetail>? Employees { get; set; }
}