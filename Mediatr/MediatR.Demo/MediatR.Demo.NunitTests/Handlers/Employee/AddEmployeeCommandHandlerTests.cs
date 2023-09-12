using AutoMapper;
using MediatR.Demo.Bll.Commands.Employee.AddEmployee;
using MediatR.Demo.Dal.Repositories.Interfaces;
using MediatR.Demo.Framework;
using Moq;

namespace MediatR.Demo.NunitTests.Handlers.Employee;

[TestFixture]
public class AddEmployeeCommandHandlerTests
{
    private AddEmployeeCommandHandler _handler;
    private Mock<IEmployeeRepository> _repository;
    private Mock<IMapper> _mapper;
    private Mock<ICompanyRepository> _companyRepository;

    [SetUp]
    public void SetUp()
    {
        _repository = new Mock<IEmployeeRepository>();
        _companyRepository = new Mock<ICompanyRepository>();
        _mapper = new Mock<IMapper>();
        _handler = new AddEmployeeCommandHandler(_repository.Object, _companyRepository.Object, _mapper.Object);
    }
    
    [Test]
    public void Unknown_Company_Should_Return_False()
    {
        var command = new AddEmployeeCommand(1, "name", "info@company.com", "sales");
        var cancellationToken = new CancellationToken();
        
        _companyRepository.Setup(x => x.GetCompany(command.CompanyId, cancellationToken)).Returns(Task.FromResult((Dal.Entities.Company)null));

        var result =_handler.Handle(command, cancellationToken);
        
        result.Result.Should().NotBeNull();
        result.Result.Should().BeOfType<Response<bool>>();
        result.Result.IsSuccess.Should().BeFalse();
    }
    
    [Test]
    public void Handle_ShouldReturnResponse()
    {
        // Arrange
        var command = new AddEmployeeCommand(1, "name", "info@company.com", "sales");
        var cancellationToken = new CancellationToken();
        var employee = new Dal.Entities.Employee { Id = 1 };
        var company = new Dal.Entities.Company { Id = 1, Name = "company name" };
        
        _mapper.Setup(x => x.Map<Dal.Entities.Employee>(command)).Returns(employee);
        _companyRepository.Setup(x => x.GetCompany(command.CompanyId, cancellationToken)).Returns(Task.FromResult(company));
        
        _repository.Setup(x => x.AddOrUpdateAsync(employee, cancellationToken)).Returns(Task.FromResult(employee));
        _repository.Setup(x => x.SaveChangesAsync(cancellationToken)).Returns(Task.CompletedTask);
        
        // Act
        var result = _handler.Handle(command, cancellationToken).Result;
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Response<bool>>();
        result.IsSuccess.Should().BeTrue();
        
        _repository.Verify(x => x.AddOrUpdateAsync(employee, cancellationToken), Times.Once);
        _repository.Verify(x => x.SaveChangesAsync(cancellationToken), Times.Once);
        
    }

    
    
    
}