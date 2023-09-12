using MediatR.Demo.Bll.Commands.Company.AddCompany;

namespace MediatR.Demo.NunitTests.Validators.Company;

[TestFixture]
public class AddCompanyCommandValidatorTests
{
    
    
    [Test]
    public void Empty_Name_Should_Be_Invalid()
    {
        var validator = new AddCompanyCommandValidator();
        var command = new AddCompanyCommand("");
        
        var result = validator.Validate(command);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
    
    [Test]
    public void To_Short_Name_Should_Be_Invalid()
    {
        var validator = new AddCompanyCommandValidator();
        var command = new AddCompanyCommand("A");
        
        var result = validator.Validate(command);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();

    }
    
    [Test]
    public void Valid_Name_Should_Be_Valid()
    {
        var validator = new AddCompanyCommandValidator();
        var command = new AddCompanyCommand("Acme");
        
        var result = validator.Validate(command);
        
        
        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }
}