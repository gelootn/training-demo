﻿using AutoMapper;
using MediatR.Demo.Dal.Repositories;
using MediatR.Demo.Dal.Repositories.Interfaces;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Commands.Company.UpdateCompany;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Response<bool>>
{
    private readonly ICompanyRepository _repository;
    private readonly IMapper _mapper;

    public UpdateCompanyCommandHandler(ICompanyRepository repository, IMapper mapper )
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<Response<bool>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _repository.GetCompany(request.Id, cancellationToken);
        if (company == null)
            return Response<bool>.FailResponse("Company Not found");

        _mapper.Map(request, company);

        await _repository.AddOrUpdateAsync(company, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        
        return new Response<bool>();
    }
}