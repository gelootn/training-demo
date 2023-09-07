using AutoMapper.QueryableExtensions;
using graphql.demo.application.Infrastructure.Mapping;
using graphql.demo.persistence.Infrastructure.Filters;
using HotChocolate;
using HotChocolate.Types;

namespace graphql.demo.application.Queries;

public class VisitQueryType
{
    [UsePaging(DefaultPageSize = 20, IncludeTotalCount = true, Order = 1)]
    [UseFiltering()]
    public IQueryable<VisitDetail> GetVisits([Service] IVisitRepository repo)
    {
        var visits = repo.GetAll();
        var details = visits.ProjectTo<VisitDetail>(VisitMap.GetConfiguration());
        return details;
    }
    
    [UsePaging(DefaultPageSize = 20, IncludeTotalCount = true, Order = 1)]
    [UseFiltering()]
    public IQueryable<CompanyDetail> GetCompanies([Service] ICompanyRepository repo)
    {
        var companies = repo.GetAll();
        var details = companies.ProjectTo<CompanyDetail>(CompanyMap.GetConfiguration());
        return details;
    }
}