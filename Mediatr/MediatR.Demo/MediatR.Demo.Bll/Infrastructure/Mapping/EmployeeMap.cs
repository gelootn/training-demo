using AutoMapper;
using MediatR.Demo.Bll.Commands.Employee.AddEmployee;
using MediatR.Demo.Bll.Commands.Employee.UpdateEmployee;
using MediatR.Demo.Bll.Models;
using MediatR.Demo.Dal.Entities;

namespace MediatR.Demo.Bll.Infrastructure.Mapping;

public class EmployeeMap : Profile
{
    public EmployeeMap()
    {
        CreateMap<AddEmployeeCommand, Employee>();
        CreateMap<UpdateEmployeeCommand, Employee>();
        CreateMap<Employee, EmployeeDetail>();
    }
}