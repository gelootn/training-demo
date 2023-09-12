using MediatR.Demo.Bll.Commands.Employee.DeleteEmployee;

namespace MediatR.Demo.XunitTests.Handlers.Employee;


public class DeleteEmployeeCommandHandlerTests
{
    private DeleteEmployeeCommandHandler _handler;
    private IEmployeeRepository _repository;



    public DeleteEmployeeCommandHandlerTests()
    {
        _repository = A.Fake<IEmployeeRepository>();
        _handler = new DeleteEmployeeCommandHandler(_repository);
    }
    
    [Fact]
    public void Handle_ShouldReturnResponse()
    {
        // Arrange
        var command = new DeleteEmployeeCommand(1, 1);
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