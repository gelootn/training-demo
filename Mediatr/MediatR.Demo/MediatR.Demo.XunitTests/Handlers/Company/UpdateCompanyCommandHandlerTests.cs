using MediatR.Demo.Bll.Commands.Company.UpdateCompany;

namespace MediatR.Demo.XunitTests.Handlers.Company;


public class UpdateCompanyCommandHandlerTests
{
    private UpdateCompanyCommandHandler _handler;
    private ICompanyRepository _repository;
    private IMapper _mapper;


    public UpdateCompanyCommandHandlerTests()
    {
        _repository = A.Fake<ICompanyRepository>();
        _mapper = A.Fake<IMapper>();
        _handler = new UpdateCompanyCommandHandler(_repository, _mapper);
    }
    
    
    [Fact]
    public void Handle_ShouldReturnResponse()
    {
        // Arrange
        var command = new UpdateCompanyCommand(1, "");
        var cancellationToken = new CancellationToken();
        var company = new Dal.Entities.Company()
        {
            Id = 1
        };
        A.CallTo(() => _repository.GetCompany(command.Id, cancellationToken)).Returns(Task.FromResult(company));
        A.CallTo(() => _mapper.Map(command, company)).Returns(company);
        A.CallTo(() => _repository.AddOrUpdateAsync(company, cancellationToken)).Returns(Task.FromResult(company));
        A.CallTo(() => _repository.SaveChangesAsync(cancellationToken)).Returns(Task.CompletedTask);
        
        // Act
        var result = _handler.Handle(command, cancellationToken).Result;
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Response<bool>>();
        result.IsSuccess.Should().BeTrue();
        
        A.CallTo(() => _repository.GetCompany(command.Id, cancellationToken)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _repository.AddOrUpdateAsync(company, cancellationToken)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _repository.SaveChangesAsync(cancellationToken)).MustHaveHappenedOnceExactly();
    }
    
    [Fact]
    public void Handle_With_UnknownCompany_ShouldReturnResponse()
    {
        // Arrange
        var command = new UpdateCompanyCommand(1, "");
        var cancellationToken = new CancellationToken();
        var company = new Dal.Entities.Company()
        {
            Id = 1
        };
        A.CallTo(() => _repository.GetCompany(command.Id, cancellationToken))
            .Returns(Task.FromResult((Dal.Entities.Company)null));
        A.CallTo(() => _mapper.Map(command, company)).Returns(company);
        A.CallTo(() => _repository.AddOrUpdateAsync(company, cancellationToken)).Returns(Task.FromResult(company));
        A.CallTo(() => _repository.SaveChangesAsync(cancellationToken)).Returns(Task.CompletedTask);
        
        // Act
        var result = _handler.Handle(command, cancellationToken).Result;
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Response<bool>>();
        result.IsSuccess.Should().BeFalse();
        
        A.CallTo(() => _repository.GetCompany(command.Id, cancellationToken)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _repository.AddOrUpdateAsync(company, cancellationToken)).MustNotHaveHappened();
        A.CallTo(() => _repository.SaveChangesAsync(cancellationToken)).MustNotHaveHappened();
    }
}