using MediatR.Demo.Bll.Commands.Employee.AddEmployee;

namespace MediatR.Demo.NunitTests.Validators.Employee;

[TestFixture]
public class AddEmployeeCommandValidatorTests
{
    [Test]
    public void Invalid_CompanyId_And_Valid_Name_And_Email_Should_Be_Invalid()
    {
        var validator = new AddEmployeeCommandValidator();
        var command = new AddEmployeeCommand(0, "John", "info@company.com","");

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
        result.Errors.Count.Should().Be(1);
    }

    [Test]
    public void Invalid_FirstName_And_Valid_CompanyId_And_Email_Should_Be_Invalid()
    {
        var validator = new AddEmployeeCommandValidator();
        var command = new AddEmployeeCommand(1, "", "info@company.com", "");

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
        result.Errors.Count.Should().Be(1);
    }

    [Test]
    public void Empty_Email_And_Valid_CompanyId_And_Name_Should_Be_Invalid()
    {
        var validator = new AddEmployeeCommandValidator();
        var command = new AddEmployeeCommand(1, "John", "","");

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public void Invalid_Email_And_Valid_CompanyId_And_Name_Should_Be_Invalid()
    {
        var validator = new AddEmployeeCommandValidator();
        var command = new AddEmployeeCommand(1, "John", "some text","");

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }

    [Test]
    public void Valid_CompanyId_And_FirstName_And_Email_Should_Be_Valid()
    {
        var validator = new AddEmployeeCommandValidator();
        var command = new AddEmployeeCommand(1, "John", "info@company.com","");

        var result = validator.Validate(command);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }
}