using AutoMapper;
using MediatR.Demo.Bll.Commands.Company.AddCompany;
using MediatR.Demo.Dal.Repositories.Interfaces;
using MediatR.Demo.Framework;
using Moq;

namespace MediatR.Demo.NunitTests.Handlers.Company;

[TestFixture]
public class AddCompanyCommandHandlerTests
{
    private AddCompanyCommandHandler _handler;
    private Mock<ICompanyRepository> _repository;
    private Mock<IMapper> _mapper;
    
    [SetUp]
    public void SetUp()
    {
        _repository = new Mock<ICompanyRepository>();
        _mapper = new Mock<IMapper>();
        _handler = new AddCompanyCommandHandler(_repository.Object, _mapper.Object); 
    }
    
    [Test]
    public void Handle_ShouldReturnResponse()
    {
        // Arrange
        var command = new AddCompanyCommand("");
        var cancellationToken = new CancellationToken();
        var company = new Dal.Entities.Company()
        {
            Id = 1
        };
        
        _mapper.Setup(x => x.Map<Dal.Entities.Company>(command)).Returns(company);
        
        _repository.Setup(x => x.AddOrUpdateAsync(company, cancellationToken)).Returns(Task.FromResult(company));
        
        _repository.Setup(x => x.SaveChangesAsync(cancellationToken)).Returns(Task.CompletedTask);
        
        // Act
        var result = _handler.Handle(command, cancellationToken).Result;
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Response<int>>();
        result.Value.Should().Be(company.Id);
        
        _repository.Verify(x => x.AddOrUpdateAsync(company, cancellationToken), Times.Once);
        _repository.Verify(x => x.SaveChangesAsync(cancellationToken), Times.Once);
        
    }
}