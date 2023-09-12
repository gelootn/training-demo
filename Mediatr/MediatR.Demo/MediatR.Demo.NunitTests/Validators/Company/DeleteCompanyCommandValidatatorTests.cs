using MediatR.Demo.Bll.Commands.Company.DeleteCompany;

namespace MediatR.Demo.NunitTests.Validators.Company;

[TestFixture]
public class DeleteCompanyCommandValidatorTests{
    
    [Test]
    public void Invalid_Id_Should_Be_Invalid(){
        var validator = new DeleteCompanyCommandValidator();
        var command = new DeleteCompanyCommand(0);

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }

    [Test]
    public void Valid_Id_Should_Be_Valid(){
        var validator = new DeleteCompanyCommandValidator();
        var command = new DeleteCompanyCommand(1);

        var result = validator.Validate(command);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }
}