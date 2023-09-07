using graphql.demo.api.Models;
using graphql.demo.application.Commands.Visit.SignIn;
using graphql.demo.application.Commands.Visit.SignOut;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace graphql.demo.api.Controllers;

[Route("api/visits")]
public class VisitController : ControllerBase
{
    private readonly IMediator _mediator;

    public VisitController(IMediator mediator )
    {
        _mediator = mediator;

    }

    [HttpPost("signin")]
    public async Task<IActionResult> RegisterVisit(StartVisitModel startVisit)
    {
        var command = new SignInCommand(startVisit.VisitorName, startVisit.VisitorEmail, startVisit.VisitorCompany, startVisit.CompanyId, startVisit.EmployeeId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
        
    [HttpPost("signout")]
    public async Task<IActionResult> StopVisit(StopVisitModel stopVisit)
    {
        var command = new SignOutCommand(stopVisit.VisitorEmail);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

}