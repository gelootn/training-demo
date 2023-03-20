using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Commands.Visit.SignOut;

public class SignOutCommand : IRequest<Response<bool>>
{
    public SignOutCommand(string visitorEmail)
    {
        VisitorEmail = visitorEmail;
    }

    public string VisitorEmail { get; }
}