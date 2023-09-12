using MediatR.Demo.Bll.Commands.Employee.AddEmployee;

namespace MediatR.Demo.XunitTests.Handlers.Employee;


public class AddEmployeeCommandHandlerTests
{
    private readonly AddEmployeeCommandHandler _handler;
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICompanyRepository _companyRepository;


    public AddEmployeeCommandHandlerTests()
    {
        _repository = A.Fake<IEmployeeRepository>();
        _companyRepository = A.Fake<ICompanyRepository>();
        _mapper = A.Fake<IMapper>();
        _handler = new AddEmployeeCommandHandler(_repository, _companyRepository, _mapper);
    }
    
    [Fact]
    public void Unknown_Company_Should_Return_False()
    {
        var command = new AddEmployeeCommand(1, "name", "info@company.com", "sales");
        var cancellationToken = new CancellationToken();
        
        A.CallTo(() => _companyRepository.GetCompany(command.CompanyId, cancellationToken)).Returns(Task.FromResult((Dal.Entities.Company)null));


        var result =_handler.Handle(command, cancellationToken);
        
        result.Result.Should().NotBeNull();
        result.Result.Should().BeOfType<Response<bool>>();
        result.Result.IsSuccess.Should().BeFalse();
    }
    
    [Fact]
    public void Handle_ShouldReturnResponse()
    {
        // Arrange
        var command = new AddEmployeeCommand(1, "name", "info@company.com", "sales");
        var cancellationToken = new CancellationToken();
        var employee = new Dal.Entities.Employee { Id = 1 };
        var company = new Dal.Entities.Company { Id = 1, Name = "company name" };
        
        A.CallTo(() => _mapper.Map<Dal.Entities.Employee>(command)).Returns(employee);
        A.CallTo(() => _companyRepository.GetCompany(command.CompanyId, cancellationToken)).Returns(Task.FromResult(company));

        A.CallTo(() => _repository.AddOrUpdateAsync(employee, cancellationToken)).Returns(Task.FromResult(employee));
        A.CallTo(() => _repository.SaveChangesAsync(cancellationToken)).Returns(Task.CompletedTask);

        
        // Act
        var result = _handler.Handle(command, cancellationToken).Result;
        
        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Response<bool>>();
        result.IsSuccess.Should().BeTrue();
        
        A.CallTo(() => _companyRepository.GetCompany(command.CompanyId, cancellationToken)).MustHaveHappenedOnceExactly();
        A.CallTo(() => _repository.SaveChangesAsync(cancellationToken)).MustHaveHappenedOnceExactly();

    }

    
    
    
}