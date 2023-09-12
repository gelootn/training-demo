using MediatR.Demo.Bll.Commands.Employee.DeleteEmployee;

namespace MediatR.Demo.NunitTests.Validators.Employee;

[TestFixture]
public class DeleteEmployeeCommandValidatorTests
{
    [Test]
    public void Invalid_Id_And_Valid_CompanyId_Should_Be_Invalid()
    {
        var validator = new DeleteEmployeeCommandValidator();
        var command = new DeleteEmployeeCommand(0, 1);

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public void Valid_Id_And_Invalid_CompanyId_Should_Be_Invalid()
    {
        var validator = new DeleteEmployeeCommandValidator();
        var command = new DeleteEmployeeCommand(1, 0);

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }

    [Test]
    public void Valid_Id_And_Valid_CompanyId_Should_Be_Valid()
    {
        var validator = new DeleteEmployeeCommandValidator();
        var command = new DeleteEmployeeCommand(1, 1);

        var result = validator.Validate(command);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }
}