using MediatR.Demo.Bll.Commands.Company.AddCompany;

namespace MediatR.Demo.XunitTests.Handlers.Company;


public class AddCompanyCommandHandlerTests
{
    private AddCompanyCommandHandler _handler;
    private ICompanyRepository _repository;
    private IMapper _mapper;
    

    public  AddCompanyCommandHandlerTests()
    {
        _repository = A.Fake<ICompanyRepository>();
        _mapper = A.Fake<IMapper>();
        _handler = new AddCompanyCommandHandler(_repository, _mapper); 
    }
    
    [Fact]
    public void Handle_ShouldReturnResponse()
    {
        // Arrange
        var command = new AddCompanyCommand("");
        var cancellationToken = new CancellationToken();
        var company = new Dal.Entities.Company()
        {
            Id = 1
        };
        
        A.CallTo(() => _mapper.Map<Dal.Entities.Company>(command)).Returns(company);
        A.CallTo(() => _repository.AddOrUpdateAsync(company, cancellationToken)).Returns(Task.FromResult(company));

        // Act
        var result = _handler.Handle(command, cancellationToken).Result;
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Response<int>>();
        result.Value.Should().Be(company.Id);
        result.IsSuccess.Should().BeTrue();
        
        A.CallTo(() => _repository.AddOrUpdateAsync(company, cancellationToken)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _repository.SaveChangesAsync(cancellationToken)).MustHaveHappenedOnceExactly();

    }
}