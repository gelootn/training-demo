﻿using FluentValidation;

namespace MediatR.Demo.Bll.Commands.Company.AddCompany;

public class AddCompanyCommandValidator : AbstractValidator<AddCompanyCommand>
{
    public AddCompanyCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
    }
}