namespace MediatR.Demo.Bll.Queries.Company.GetAllCompanies;

public class GetAllCompaniesQueryResult
{
    public ICollection<Models.CompanyDetail> Companies { get; set; }
}