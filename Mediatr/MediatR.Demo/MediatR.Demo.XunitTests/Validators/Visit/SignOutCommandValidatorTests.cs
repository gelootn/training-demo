using MediatR.Demo.Bll.Commands.Visit.SignOut;

namespace MediatR.Demo.XunitTests.Validators.Visit;

public class SignOutCommandValidatorTests
{
    private SignOutCommandValidator _validator;
    
    public  SignOutCommandValidatorTests()
    {
        _validator = new SignOutCommandValidator();
    }

    [Fact]
    public void Empty_Email_Should_Be_Invalid()
    {
        var command = new SignOutCommand("");
        var result = _validator.Validate(command);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Fact]
    public void Invalid_Email_Should_Be_Invalid()
    {
        var command = new SignOutCommand("not an email");
        var result = _validator.Validate(command);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public void Valid_Email_Should_Be_Valid()
    {
        var command = new SignOutCommand("email@company.com");
        var result = _validator.Validate(command);
        
        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }
}