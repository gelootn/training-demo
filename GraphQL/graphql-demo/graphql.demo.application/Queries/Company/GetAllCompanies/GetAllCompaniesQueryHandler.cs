using MediatR;

namespace graphql.demo.application.Queries.Company.GetAllCompanies;

public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, GetAllCompaniesQueryResult>
{
    private readonly ICompanyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCompaniesQueryHandler(ICompanyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<GetAllCompaniesQueryResult> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _repository.GetCompanies();
        var result = new GetAllCompaniesQueryResult
        {
            Companies = _mapper.Map<ICollection<Models.CompanyDetail>>(companies)
        };
        return result;
    }
}