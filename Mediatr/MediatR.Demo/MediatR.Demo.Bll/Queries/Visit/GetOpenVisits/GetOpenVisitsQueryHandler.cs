using AutoMapper;
using MediatR.Demo.Bll.Models;
using MediatR.Demo.Dal.Repositories.Interfaces;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Queries.Visit.GetOpenVisits;

public class GetOpenVisitsQueryHandler : IRequestHandler<GetOpenVisitsQuery, Response<VisitDetail>>
{
    private readonly IVisitRepository _visitRepository;
    private readonly IMapper _mapper;

    public GetOpenVisitsQueryHandler(IVisitRepository visitRepository, IMapper mapper)
    {
        _visitRepository = visitRepository;
        _mapper = mapper;
    }
    public async Task<Response<VisitDetail>> Handle(GetOpenVisitsQuery request, CancellationToken cancellationToken)
    {
        var visits = await _visitRepository.GetOpenVisits(cancellationToken);
        return new Response<VisitDetail>(_mapper.Map<ICollection<VisitDetail>>(visits));
    }
}