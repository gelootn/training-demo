
using MediatR.Demo.Bll.Models;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Queries.Company.GetOneCompany;

public record GetOneCompanyQuery(int CompanyId) : IRequest<Response<CompanyDetail>>;
