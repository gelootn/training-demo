using MediatR.Demo.Bll.Infrastructure;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Commands.Company.UpdateCompany;

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