using AutoMapper;
using MediatR.Demo.Bll.Models;
using MediatR.Demo.Dal.Infrastructure.Filters;
using MediatR.Demo.Dal.Repositories.Interfaces;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Queries.Visit.GetVisits;

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