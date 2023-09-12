using MediatR.Demo.Bll.Commands.Employee.UpdateEmployee;

namespace MediatR.Demo.NunitTests.Validators.Employee;

[TestFixture]
public class UpdateEmployeeCommandValidatorTests
{
    [Test]
    public void Invalid_Id_And_Valid_CompanyId_And_Name_And_Email_Should_Be_Invalid()
    {
        var validator = new UpdateEmployeeCommandValidator();
        var command = new UpdateEmployeeCommand(0, 1, "John", "info@company.com", "");
        var result = validator.Validate(command);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public void Invalid_CompanyId_And_Valid_Id_And_Name_And_Email_Should_Be_Invalid()
    {
        var validator = new UpdateEmployeeCommandValidator();
        var command = new UpdateEmployeeCommand(1, 0, "John", "info@company.com", "");
        var result = validator.Validate(command);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }   
    
    [Test]
    public void Empty_Name_And_Valid_Id_And_CompanyId_And_Email_Should_Be_Invalid()
    {
        var validator = new UpdateEmployeeCommandValidator();
        var command = new UpdateEmployeeCommand(1, 1, "", "info@company.com", "");
        var result = validator.Validate(command);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public void To_Short_Name_And_Valid_Id_And_CompanyId_And_Email_Should_Be_Invalid()
    {
        var validator = new UpdateEmployeeCommandValidator();
        var command = new UpdateEmployeeCommand(1, 1, "a", "info@company.com", "");
        var result = validator.Validate(command);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public void Empty_Email_And_Valid_Id_And_CompanyId_And_Name_Should_Be_Invalid()
    {
        var validator = new UpdateEmployeeCommandValidator();
        var command = new UpdateEmployeeCommand(1, 1, "John", "", "");
        var result = validator.Validate(command);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public void Invalid_Email_And_Valid_Id_And_CompanyId_And_Name_Should_Be_Invalid()
    {
        var validator = new UpdateEmployeeCommandValidator();
        var command = new UpdateEmployeeCommand(1, 1, "John", "not an email", "");
        var result = validator.Validate(command);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public void Valid_Id_And_CompanyId_And_Name_And_Email_Should_Be_Invalid()
    {
        var validator = new UpdateEmployeeCommandValidator();
        var command = new UpdateEmployeeCommand(1, 1, "John", "info@company.com", "");
        var result = validator.Validate(command);
        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }
    
}