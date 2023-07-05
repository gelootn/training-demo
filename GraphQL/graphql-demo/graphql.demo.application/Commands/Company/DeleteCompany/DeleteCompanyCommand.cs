using graphql.demo.application.Infrastructure;
using MediatR;

namespace graphql.demo.application.Commands.Company.DeleteCompany;

public class DeleteCompanyCommand : IRequest<Response<bool>>, IValidatable
{
    public DeleteCompanyCommand(int id)
    {
        Id = id;
    }
    public int Id { get; }
}