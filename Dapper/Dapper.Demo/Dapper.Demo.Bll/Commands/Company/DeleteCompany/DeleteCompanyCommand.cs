using Dapper.Demo.Bll.Infrastructure;
using Dapper.Demo.Framework;
using MediatR;

namespace Dapper.Demo.Bll.Commands.Company.DeleteCompany;

public class DeleteCompanyCommand : IRequest<Response<bool>>, IValidatable
{
    public DeleteCompanyCommand(int id)
    {
        Id = id;
    }
    public int Id { get; }
}