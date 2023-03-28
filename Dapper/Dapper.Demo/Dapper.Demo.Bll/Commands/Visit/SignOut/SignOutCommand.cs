using Dapper.Demo.Framework;
using MediatR;

namespace Dapper.Demo.Bll.Commands.Visit.SignOut;

public class SignOutCommand : IRequest<Response<bool>>
{
    public SignOutCommand(string visitorEmail)
    {
        VisitorEmail = visitorEmail;
    }

    public string VisitorEmail { get; }
}