using MediatR.Demo.Bll.Commands.Visit.SignIn;

namespace MediatR.Demo.NunitTests.Validators.Visit;

[TestFixture]
public class SignInCommandValidatorTests
{
    private SignInCommandValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new SignInCommandValidator();
    }

    [Test]
    public void Empty_VisitorName_Should_Be_Invalid()
    {
        var command = new SignInCommand("", "email@company.com", "company", 1, 1);
        var result = _validator.Validate(command);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public void Empty_VisitorCompany_Should_Be_Invalid()
    {
        var command = new SignInCommand("Name", "email@company.com", "", 1, 1);
        var result = _validator.Validate(command);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public void Empty_Email_Should_Be_Invalid()
    {
        var command = new SignInCommand("Name", "", "company", 1, 1);
        var result = _validator.Validate(command);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public void Invalid_Email_Should_Be_Invalid()
    {
        var command = new SignInCommand("Name", "not an email", "company", 1, 1);
        var result = _validator.Validate(command);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public void Invalid_CompanyId_Should_Be_Invalid()
    {
        var command = new SignInCommand("Name", "email@company.com", "company", 0, 1);
        var result = _validator.Validate(command);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public void Invalid_EmployeeId_Should_Be_Invalid()
    {
        var command = new SignInCommand("Name", "email@company.com", "company", 1, 0);
        var result = _validator.Validate(command);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }

    [Test]
    public void Valid_Command_Should_Be_Valid()
    {
        var command = new SignInCommand("Name", "email@company.com", "company", 1, 1);
        var result = _validator.Validate(command);
        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }
}