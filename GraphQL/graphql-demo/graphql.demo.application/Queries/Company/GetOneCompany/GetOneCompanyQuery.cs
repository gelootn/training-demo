using graphql.demo.application.Models;
using MediatR;

namespace graphql.demo.application.Queries.Company.GetOneCompany;

public record GetOneCompanyQuery(int CompanyId) : IRequest<Response<CompanyDetail>>;
