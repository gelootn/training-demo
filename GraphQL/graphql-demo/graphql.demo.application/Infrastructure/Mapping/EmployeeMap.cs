using graphql.demo.application.Commands.Employee.AddEmployee;
using graphql.demo.application.Commands.Employee.UpdateEmployee;
using graphql.demo.application.Models;
using graphql.demo.persistence.Entities;

namespace graphql.demo.application.Infrastructure.Mapping;

public class EmployeeMap : Profile
{
    public EmployeeMap()
    {
        CreateMap<AddEmployeeCommand, Employee>();
        CreateMap<UpdateEmployeeCommand, Employee>();
        CreateMap<Employee, EmployeeDetail>();
    }
}