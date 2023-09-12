using MediatR.Demo.Bll.Commands.Company.DeleteCompany;
using MediatR.Demo.Dal.Repositories.Interfaces;
using MediatR.Demo.Framework;
using Moq;

namespace MediatR.Demo.NunitTests.Handlers.Company;

[TestFixture]
public class DeleteCompanyCommandHandlerTests
{
    private DeleteCompanyCommandHandler _handler;
    private Mock<ICompanyRepository> _repository;

    [SetUp]
    public void SetUp()
    {
        _repository = new Mock<ICompanyRepository>();
        _handler = new DeleteCompanyCommandHandler(_repository.Object);
    }
    
    [Test]
    public void Handle_ShouldReturnResponse()
    {
        // Arrange
        var command = new DeleteCompanyCommand(1);
        var cancellationToken = new CancellationToken();
        _repository.Setup(x => x.DeleteAsync(command.Id, cancellationToken)).Returns(Task.CompletedTask);
        _repository.Setup(x => x.SaveChangesAsync(cancellationToken)).Returns(Task.CompletedTask);
        
        // Act
        var result = _handler.Handle(command, cancellationToken).Result;
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Response<bool>>();
        
        _repository.Verify(x => x.DeleteAsync(command.Id, cancellationToken), Times.Once);
        _repository.Verify(x => x.SaveChangesAsync(cancellationToken), Times.Once);
    }
}