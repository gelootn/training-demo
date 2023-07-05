using graphql.demo.application.Infrastructure;
using MediatR;

namespace graphql.demo.application.Commands.Employee.DeleteEmployee;

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