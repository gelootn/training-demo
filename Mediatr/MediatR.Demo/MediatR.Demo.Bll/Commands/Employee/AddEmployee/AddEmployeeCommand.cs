using MediatR.Demo.Bll.Infrastructure;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Commands.Employee.AddEmployee;

public class AddEmployeeCommand : IRequest<Response<bool>>, IValidatable
{
    public AddEmployeeCommand(int companyId, string name, string email, string function)
    {
        CompanyId = companyId;
        Name = name;
        Email = email;
        Function = function;
    }
    public int CompanyId { get; }
    public string Name { get; }
    public string Email { get; }
    public string Function { get; }
}