using Dapper.Demo.Bll.Infrastructure;
using FluentValidation;

namespace Dapper.Demo.Bll.Commands.Visit.SignOut;

public class SignOutCommandValidator : AbstractValidator<SignOutCommand>, IValidatable
{
    public SignOutCommandValidator()
    {
        RuleFor(x => x.VisitorEmail).NotEmpty().EmailAddress();
    }
}