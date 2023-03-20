using AutoMapper;
using MediatR.Demo.Dal.Repositories;
using MediatR.Demo.Dal.Repositories.Interfaces;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Commands.Employee.UpdateEmployee;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Response<bool>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    
    public async Task<Response<bool>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployee(request.Id, cancellationToken);
        if (employee == null)
            return Response<bool>.FailResponse("Employee not found");

        _mapper.Map(request, employee);

        await _employeeRepository.AddOrUpdateAsync(employee,cancellationToken);
        await _employeeRepository.SaveChangesAsync(cancellationToken);

        return Response<bool>.SuccessResponse();
    }
}