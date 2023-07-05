using graphql.demo.application.Infrastructure;
using MediatR;

namespace graphql.demo.application.Commands.Employee.AddEmployee;

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