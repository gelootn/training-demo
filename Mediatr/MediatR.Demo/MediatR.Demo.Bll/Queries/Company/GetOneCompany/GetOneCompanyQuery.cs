namespace MediatR.Demo.Bll.Queries.Company.GetOneCompany;

public record GetOneCompanyQuery(int CompanyId) : IRequest<GetOneCompanyQueryResult>;
