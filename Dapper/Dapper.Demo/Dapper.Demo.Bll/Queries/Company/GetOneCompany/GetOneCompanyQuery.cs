namespace Dapper.Demo.Bll.Queries.Company.GetOneCompany;

public record GetOneCompanyQuery(int CompanyId) : IRequest<Response<CompanyDetail>>;
