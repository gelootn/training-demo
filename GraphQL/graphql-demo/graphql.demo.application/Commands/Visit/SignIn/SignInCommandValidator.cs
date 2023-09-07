using FluentValidation;

namespace graphql.demo.application.Commands.Visit.SignIn;

public class SignInCommandValidator : AbstractValidator<SignInCommand>
{
    public SignInCommandValidator()
    {
        RuleFor(x => x.VisitorName).NotEmpty();
        RuleFor(x => x.VisitorCompany).NotEmpty();
        RuleFor(x => x.VisitorEmail).NotEmpty().EmailAddress();
        RuleFor(x => x.CompanyId).GreaterThan(0);
        RuleFor(x => x.EmployeeId).GreaterThan(0);
    }
}