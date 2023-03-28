using AutoMapper;
using Dapper.Demo.Bll.Commands.Employee.AddEmployee;
using Dapper.Demo.Bll.Commands.Employee.UpdateEmployee;
using Dapper.Demo.Bll.Models;
using Dapper.Demo.Dal.Entities;

namespace Dapper.Demo.Bll.Infrastructure.Mapping;

public class EmployeeMap : Profile
{
    public EmployeeMap()
    {
        CreateMap<AddEmployeeCommand, Employee>();
        CreateMap<UpdateEmployeeCommand, Employee>();
        CreateMap<Employee, EmployeeDetail>();
    }
}