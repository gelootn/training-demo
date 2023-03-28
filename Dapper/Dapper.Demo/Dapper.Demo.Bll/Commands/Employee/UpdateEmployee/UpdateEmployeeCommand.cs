using Dapper.Demo.Bll.Infrastructure;
using Dapper.Demo.Framework;
using MediatR;

namespace Dapper.Demo.Bll.Commands.Employee.UpdateEmployee;

public class UpdateEmployeeCommand : IRequest<Response<bool>>, IValidatable
{
    public UpdateEmployeeCommand(int id, int companyId, string name, string email, string function)
    {
        Id = id;
        CompanyId = companyId;
        Name = name;
        Email = email;
        Function = function;
    }

    public int Id { get; }
    public int CompanyId { get; }
    public string Name { get; }
    public string Email { get; }
    public string Function { get; }
}