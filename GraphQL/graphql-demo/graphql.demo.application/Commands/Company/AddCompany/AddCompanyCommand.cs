using graphql.demo.application.Infrastructure;
using MediatR;

namespace graphql.demo.application.Commands.Company.AddCompany;

public class AddCompanyCommand : IRequest<Response<int>>, IValidatable
{
    public AddCompanyCommand(string name)
    {
        Name = name;
    }
    public string Name { get; }
}
