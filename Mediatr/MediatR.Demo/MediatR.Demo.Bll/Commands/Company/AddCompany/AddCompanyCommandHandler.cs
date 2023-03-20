using AutoMapper;
using MediatR.Demo.Dal.Repositories;
using MediatR.Demo.Dal.Repositories.Interfaces;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Commands.Company.AddCompany;

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
        var company = _mapper.Map<Dal.Entities.Company>(request);
        await _repository.AddOrUpdateAsync(company, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return new Response<int>(company.Id);
    }
}