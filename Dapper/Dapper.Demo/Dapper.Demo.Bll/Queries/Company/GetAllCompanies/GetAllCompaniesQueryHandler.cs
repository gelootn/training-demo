namespace Dapper.Demo.Bll.Queries.Company.GetAllCompanies;

public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, Response<CompanyDetail>>
{
    private readonly ICompanyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCompaniesQueryHandler(ICompanyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Response<CompanyDetail>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _repository.GetCompanies();
        return new Response<CompanyDetail>(_mapper.Map<ICollection<CompanyDetail>>(companies));
    }
}