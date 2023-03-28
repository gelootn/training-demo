using Dapper.Demo.Bll.Commands.Visit.SignIn;
using Dapper.Demo.Bll.Commands.Visit.SignOut;
using Dapper.Demo.Bll.Queries.Visit.GetOpenVisits;
using Dapper.Demo.Bll.Queries.Visit.GetVisits;
using Dapper.Demo.EndPoint.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Demo.EndPoint.Controllers;

[Route("api/[controller]")]
public class VisitController : ControllerBase
{
    private readonly IMediator _mediator;

    public VisitController(IMediator mediator )
    {
        _mediator = mediator;

    }

    [HttpGet("open")]
    public async Task<ActionResult<VisitModel>> OpenVisits()
    {
        var command = new GetOpenVisitsQuery();
        var result = await _mediator.Send(command);
        return Ok(result);
    }
        
    [HttpGet]
    public async Task<ActionResult<VisitModel>> Visits()
    {
        var command = new GetVisitsQuery();
        var result = await _mediator.Send(command);
        return Ok(result);
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