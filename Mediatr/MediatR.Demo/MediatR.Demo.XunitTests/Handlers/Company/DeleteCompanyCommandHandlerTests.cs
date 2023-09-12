using MediatR.Demo.Bll.Commands.Company.DeleteCompany;

namespace MediatR.Demo.XunitTests.Handlers.Company;


public class DeleteCompanyCommandHandlerTests
{
    private DeleteCompanyCommandHandler _handler;
    private ICompanyRepository _repository;


    public DeleteCompanyCommandHandlerTests()
    {
        _repository = A.Fake<ICompanyRepository>();
        _handler = new DeleteCompanyCommandHandler(_repository);
    }
    
    [Fact]
    public void Handle_ShouldReturnResponse()
    {
        // Arrange
        var command = new DeleteCompanyCommand(1);
        var cancellationToken = new CancellationToken();
        A.CallTo(() => _repository.DeleteAsync(command.Id, cancellationToken)).Returns(Task.CompletedTask);
        A.CallTo(() => _repository.SaveChangesAsync(cancellationToken)).Returns(Task.CompletedTask);
        
        // Act
        var result = _handler.Handle(command, cancellationToken).Result;
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Response<bool>>();
        result.IsSuccess.Should().BeTrue();
        
        A.CallTo(() => _repository.DeleteAsync(command.Id, cancellationToken)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _repository.SaveChangesAsync(cancellationToken)).MustHaveHappenedOnceExactly();

    }
}