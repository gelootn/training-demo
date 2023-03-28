namespace Dapper.Demo.EndPoint.Models;

public record EmployeeModel(int Id, string Name, string Email, string Function, int CompanyId) : ModelBase(Id);