using MediatR.Demo.Dal.Repositories;
using MediatR.Demo.Dal.Repositories.Interfaces;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Commands.Visit.SignOut;

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