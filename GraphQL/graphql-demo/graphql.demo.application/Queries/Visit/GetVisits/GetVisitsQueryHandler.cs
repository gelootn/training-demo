using AutoMapper;
using graphql.demo.application.Models;
using graphql.demo.framework;
using graphql.demo.persistence.Infrastructure.Filters;
using graphql.demo.persistence.Repositories.Interfaces;
using MediatR;

namespace graphql.demo.application.Queries.Visit.GetVisits;

public class GetVisitsQueryHandler : IRequestHandler<GetVisitsQuery, Response<VisitDetail>>
{
    private readonly IVisitRepository _visitRepository;
    private readonly IMapper _mapper;

    public GetVisitsQueryHandler(IVisitRepository visitRepository, IMapper mapper)
    {
        _visitRepository = visitRepository;
        _mapper = mapper;
    }
    public async Task<Response<VisitDetail>> Handle(GetVisitsQuery request, CancellationToken cancellationToken)
    {
        var filter = _mapper.Map<VisitFilter>(request);
        var visits = await _visitRepository.GetVisits(filter, cancellationToken);
        return new Response<VisitDetail>(_mapper.Map<ICollection<VisitDetail>>(visits));
    }
}