namespace graphql.demo.api.Models;

public record EmployeeModel(int Id, string Name, string Email, string Function, int CompanyId) : ModelBase(Id);