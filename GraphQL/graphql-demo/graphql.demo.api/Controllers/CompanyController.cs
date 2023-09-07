using graphql.demo.api.Models;
using graphql.demo.application.Commands.Company.AddCompany;
using graphql.demo.application.Commands.Company.DeleteCompany;
using graphql.demo.application.Commands.Company.UpdateCompany;
using graphql.demo.application.Commands.Employee.AddEmployee;
using graphql.demo.application.Commands.Employee.DeleteEmployee;
using graphql.demo.application.Commands.Employee.UpdateEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace graphql.demo.api.Controllers;

[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
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