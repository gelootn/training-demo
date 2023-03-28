namespace Dapper.Demo.Bll.Queries.Company.GetOneCompany;

internal class GetOneCompanyQueryHandler : IRequestHandler<GetOneCompanyQuery, Response<CompanyDetail>>
{
    private readonly ICompanyRepository _repository;
    private readonly IMapper _mapper;

    public GetOneCompanyQueryHandler(ICompanyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<CompanyDetail>> Handle(GetOneCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await _repository.GetCompany(request.CompanyId, cancellationToken);
        return new Response<CompanyDetail>(_mapper.Map<CompanyDetail>(company));
    }
}

