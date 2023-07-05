using AutoMapper.QueryableExtensions;
using graphql.demo.application.Infrastructure.Mapping;
using graphql.demo.persistence.Infrastructure.Filters;
using HotChocolate;
using HotChocolate.Types;

namespace graphql.demo.application.Queries;

public class VisitQueryType
{
    [UsePaging(DefaultPageSize = 20, IncludeTotalCount = true)]
    [UseFiltering]
    public IQueryable<VisitDetail> GetVisits([Service] IVisitRepository repo)
    {
        var visits = repo.GetAll();
        var details = visits.ProjectTo<VisitDetail>(VisitMap.GetConfiguration());
        return details;
    }


    /*public async Task<IEnumerable<VisitDetail>> VisitsAsync([Service] IVisitRepository repo, [Service] IMapper mapper, VisitFilter filter, CancellationToken cancellationToken)
    {
        var visits = await repo.GetVisits(filter, cancellationToken);
        return mapper.Map<ICollection<VisitDetail>>(visits);
    }

    public async Task<VisitDetail> VisitAsync([Service] IVisitRepository repo, [Service] IMapper mapper, string email, CancellationToken cancellationToken)
    {
        var visit = await repo.GetVisitByVisitorEmail(email, cancellationToken);
        return mapper.Map<VisitDetail>(visit);
    }*/
}