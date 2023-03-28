using Dapper.Demo.Dal.Repositories.Interfaces;
using Dapper.Demo.Framework;
using MediatR;

namespace Dapper.Demo.Bll.Commands.Visit.SignOut;

public class SignOutCommandHandler : IRequestHandler<SignOutCommand, Response<bool>>
{
    private readonly IVisitRepository _visitRepository;

    public SignOutCommandHandler(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }
    public async Task<Response<bool>> Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
        var visit = await _visitRepository.GetVisitByVisitorEmail(request.VisitorEmail, cancellationToken);
        if (visit == null)
            return Response<bool>.FailResponse("Visit for email not found");
        
        visit.Stop = DateTime.Now;

        await _visitRepository.AddOrUpdateAsync(visit, cancellationToken);
        await _visitRepository.SaveChangesAsync(cancellationToken);

        return Response<bool>.SuccessResponse();
    }
}