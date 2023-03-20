using FluentValidation;

namespace MediatR.Demo.Bll.Commands.Company.DeleteCompany;

public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}