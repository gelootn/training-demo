using FluentValidation;

namespace Dapper.Demo.Bll.Commands.Company.AddCompany;

public class AddCompanyCommandValidator : AbstractValidator<AddCompanyCommand>
{
    public AddCompanyCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
    }
}