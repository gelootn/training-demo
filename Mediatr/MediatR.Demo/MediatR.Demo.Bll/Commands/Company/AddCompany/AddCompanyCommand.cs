using MediatR.Demo.Bll.Infrastructure;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Commands.Company.AddCompany;

public class AddCompanyCommand : IRequest<Response<int>>, IValidatable
{
    public AddCompanyCommand(string name)
    {
        Name = name;
    }
    public string Name { get; }
}
