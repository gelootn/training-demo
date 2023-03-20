using FluentValidation;
using MediatR.Demo.Bll.Infrastructure;

namespace MediatR.Demo.Bll.Commands.Visit.SignOut;

public class SignOutCommandValidator : AbstractValidator<SignOutCommand>, IValidatable
{
    public SignOutCommandValidator()
    {
        RuleFor(x => x.VisitorEmail).NotEmpty().EmailAddress();
    }
}