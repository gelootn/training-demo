using MediatR;

namespace graphql.demo.application.Commands.Company.AddCompany;

public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, Response<int>>
{
    private readonly ICompanyRepository _repository;
    private readonly IMapper _mapper;

    public AddCompanyCommandHandler(ICompanyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<Response<int>> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = _mapper.Map<persistence.Entities.Company>(request);
        await _repository.AddOrUpdateAsync(company, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return new Response<int>(company.Id);
    }
}