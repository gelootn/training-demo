using MediatR.Demo.Bll.Infrastructure;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Commands.Company.DeleteCompany;

public class DeleteCompanyCommand : IRequest<Response<bool>>, IValidatable
{
    public DeleteCompanyCommand(int id)
    {
        Id = id;
    }
    public int Id { get; }
}