

using MediatR.Demo.Bll.Commands.Visit.SignIn;
using MediatR.Demo.Bll.Commands.Visit.SignOut;
using MediatR.Demo.Bll.Queries.Visit.GetOpenVisits;
using MediatR.Demo.Bll.Queries.Visit.GetVisits;
using MediatR.Demo.EndPoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.Demo.EndPoint.Controllers;

[Route("api/visits")]
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