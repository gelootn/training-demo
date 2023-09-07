using MediatR;

namespace graphql.demo.application.Commands.Visit.SignOut;

public class SignOutCommand : IRequest<Response<bool>>
{
    public SignOutCommand(string visitorEmail)
    {
        VisitorEmail = visitorEmail;
    }

    public string VisitorEmail { get; }
}