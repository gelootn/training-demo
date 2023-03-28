﻿using FluentValidation;

namespace Dapper.Demo.Bll.Commands.Employee.AddEmployee;

public class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
{
    public AddEmployeeCommandValidator()
    {
        RuleFor(x => x.CompanyId).GreaterThan(0);
        RuleFor(x => x.Name).MinimumLength(2);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}