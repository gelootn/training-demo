using FluentValidation;
using graphql.demo.application.Infrastructure;

namespace graphql.demo.application.Commands.Visit.SignOut;

public class SignOutCommandValidator : AbstractValidator<SignOutCommand>, IValidatable
{
    public SignOutCommandValidator()
    {
        RuleFor(x => x.VisitorEmail).NotEmpty().EmailAddress();
    }
}