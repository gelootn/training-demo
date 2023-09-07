using graphql.demo.application.Infrastructure;
using MediatR;

namespace graphql.demo.application.Commands.Company.UpdateCompany;

public class UpdateCompanyCommand : IRequest<Response<bool>>, IValidatable
{
    public UpdateCompanyCommand(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id { get;  }
    public string Name { get; }
}