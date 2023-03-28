using AutoMapper;
using Dapper.Demo.Dal.Repositories.Interfaces;
using Dapper.Demo.Framework;
using MediatR;

namespace Dapper.Demo.Bll.Commands.Employee.AddEmployee;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Response<bool>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _companyRepository = companyRepository;
        _mapper = mapper;
    }
    public async Task<Response<bool>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetCompany(request.CompanyId, cancellationToken);
        if (company == null)
            return Response<bool>.FailResponse("No company found");
        
        var employee = _mapper.Map<Dapper.Demo.Dal.Entities.Employee>(request);
        await _employeeRepository.AddOrUpdateAsync(employee, cancellationToken);
        await _employeeRepository.SaveChangesAsync(cancellationToken);
        
        return Response<bool>.SuccessResponse();
    }
}