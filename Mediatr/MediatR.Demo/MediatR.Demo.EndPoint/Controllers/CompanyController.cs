
using MediatR.Demo.Bll.Commands.Company.AddCompany;
using MediatR.Demo.Bll.Commands.Company.DeleteCompany;
using MediatR.Demo.Bll.Commands.Company.UpdateCompany;
using MediatR.Demo.Bll.Commands.Employee.AddEmployee;
using MediatR.Demo.Bll.Commands.Employee.DeleteEmployee;
using MediatR.Demo.Bll.Commands.Employee.UpdateEmployee;
using MediatR.Demo.Bll.Queries.Company.GetAllCompanies;
using MediatR.Demo.Bll.Queries.Company.GetOneCompany;
using MediatR.Demo.EndPoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.Demo.EndPoint.Controllers;

[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var command = new GetAllCompaniesQuery();
        var result = await _mediator.Send(command);
        
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var command = new GetOneCompanyQuery(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody]CompanyModel model)
    {
        var command = new AddCompanyCommand(model.Name);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
        
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute]int id, [FromBody]CompanyModel model)
    {
        if (id != model.Id)
            return BadRequest("route id and body id do not match");
        var command = new UpdateCompanyCommand(model.Id, model.Name);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        var command = new DeleteCompanyCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("{id}/employee")]
    public async Task<IActionResult> AddEmployeeToCompany([FromRoute] int id,[FromBody]EmployeeModel employee)
    {
        if(id != employee.CompanyId)
            return BadRequest("route id and body id do not match");
        var command = new AddEmployeeCommand(id, employee.Name, employee.Email, employee.Function);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
        
        
    [HttpPut("{id}/employee")]
    public async Task<IActionResult> UpdateEmployee([FromRoute] int id,[FromBody]EmployeeModel employee)
    {
        var command = new UpdateEmployeeCommand(id, employee.CompanyId, employee.Name, employee.Email, employee.Function);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
        
    [HttpDelete("{id}/employee/{employeeId}")]
    public async Task<IActionResult> RemoveEmployee([FromRoute] int id, [FromRoute] int employeeId)
    {
        var command = new DeleteEmployeeCommand(employeeId, id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}