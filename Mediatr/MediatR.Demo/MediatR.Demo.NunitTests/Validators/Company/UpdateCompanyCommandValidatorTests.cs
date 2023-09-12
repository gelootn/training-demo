using MediatR.Demo.Bll.Commands.Company.UpdateCompany;

namespace MediatR.Demo.NunitTests.Validators.Company;

[TestFixture]
public class UpdateCompanyCommandValidatorTests
{
    [Test]
    public void Empty_Name_And_Valid_Id_Should_Be_Invalid()
    {
        var validator = new UpdateCompanyCommandValidator();
        var command = new UpdateCompanyCommand(1, "");

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }

    [Test]
    public void To_Short_Name_And_Valid_Id_Should_Be_Invalid()
    {
        var validator = new UpdateCompanyCommandValidator();
        var command = new UpdateCompanyCommand(1,"A");

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();

    }

    [Test]
    public void Valid_Name_And_Valid_Id_Should_Be_Valid()
    {
        var validator = new UpdateCompanyCommandValidator();
        var command = new UpdateCompanyCommand(1,"Acme");

        var result = validator.Validate(command);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }
    
    [Test]
    public void Invalid_Id_And_Valid_Name_Should_Be_Invalid(){
        var validator = new UpdateCompanyCommandValidator();
        var command = new UpdateCompanyCommand(0,"Acme");

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
}