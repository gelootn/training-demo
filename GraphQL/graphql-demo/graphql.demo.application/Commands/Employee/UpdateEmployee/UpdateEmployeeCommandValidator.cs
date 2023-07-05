using FluentValidation;

namespace graphql.demo.application.Commands.Employee.UpdateEmployee;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.CompanyId).GreaterThan(0);
        RuleFor(x => x.Name).MinimumLength(2);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}