using Dapper.Demo.Bll.Infrastructure;
using Dapper.Demo.Framework;
using MediatR;

namespace Dapper.Demo.Bll.Commands.Company.AddCompany;

public class AddCompanyCommand : IRequest<Response<int>>, IValidatable
{
    public AddCompanyCommand(string name)
    {
        Name = name;
    }
    public string Name { get; }
}
