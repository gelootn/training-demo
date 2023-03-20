using MediatR.Demo.Bll.Infrastructure;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Commands.Employee.DeleteEmployee;

public class DeleteEmployeeCommand : IRequest<Response<bool>>, IValidatable
{
    public DeleteEmployeeCommand(int id, int companyId)
    {
        Id = id;
        CompanyId = companyId;
    }
    public int Id { get; }
    public int CompanyId { get; }
}