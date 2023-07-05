using graphql.demo.persistence.Entities;
using MediatR;

namespace graphql.demo.application.Commands.Visit.SignIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, Response<bool>>
{
    private readonly IVisitorRepository _visitorRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IVisitRepository _visitRepository;

    public SignInCommandHandler(IVisitorRepository visitorRepository, ICompanyRepository companyRepository, IVisitRepository visitRepository)
    {
        _visitorRepository = visitorRepository;
        _companyRepository = companyRepository;
        _visitRepository = visitRepository;
    }
    
    public async Task<Response<bool>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var visitor = await _visitorRepository.GetVisitorByEmail(request.VisitorEmail, cancellationToken);
        if (visitor == null)
            visitor = new Visitor
            {
                Email = request.VisitorEmail,
                Name = request.VisitorName,
                Company = request.VisitorCompany
            };

        var company = await _companyRepository.GetCompany(request.CompanyId, cancellationToken);
        if (company == null)
            return Response<bool>.FailResponse("Company not found");

        var employee = company.Employees.FirstOrDefault(x => x.Id == request.EmployeeId);
        if (employee == null)
            return Response<bool>.FailResponse("Employee not found");

        var visit = new persistence.Entities.Visit
        {
            Visitor = visitor,
            Company = company,
            Employee = employee,
            Start = DateTime.Now
        };

        await _visitRepository.AddOrUpdateAsync(visit, cancellationToken);
        await _visitRepository.SaveChangesAsync(cancellationToken);

        return Response<bool>.SuccessResponse();
        
    }
}