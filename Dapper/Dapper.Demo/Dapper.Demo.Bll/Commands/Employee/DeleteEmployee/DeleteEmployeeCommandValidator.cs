using FluentValidation;

namespace Dapper.Demo.Bll.Commands.Employee.DeleteEmployee;

public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.CompanyId).GreaterThan(0);
    }
}