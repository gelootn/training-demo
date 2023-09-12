using MediatR.Demo.Bll.Commands.Employee.DeleteEmployee;
using MediatR.Demo.Dal.Repositories.Interfaces;
using MediatR.Demo.Framework;
using Moq;

namespace MediatR.Demo.NunitTests.Handlers.Employee;

[TestFixture]
public class DeleteEmployeeCommandHandlerTests
{
    private DeleteEmployeeCommandHandler _handler;
    private Mock<IEmployeeRepository> _repository;


    [SetUp]
    public void SetUp()
    {
        _repository = new Mock<IEmployeeRepository>();
        _handler = new DeleteEmployeeCommandHandler(_repository.Object);
    }
    
    [Test]
    public void Handle_ShouldReturnResponse()
    {
        // Arrange
        var command = new DeleteEmployeeCommand(1, 1);
        var cancellationToken = new CancellationToken();
        var employee = new Dal.Entities.Employee()
        {
            Id = 1, CompanyId = 1
        };

        _repository.Setup(x => x.GetEmployee(command.Id, cancellationToken)).Returns(Task.FromResult(employee));
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