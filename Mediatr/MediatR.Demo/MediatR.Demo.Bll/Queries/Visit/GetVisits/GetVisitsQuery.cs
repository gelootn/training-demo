using MediatR.Demo.Bll.Models;
using MediatR.Demo.Framework;

namespace MediatR.Demo.Bll.Queries.Visit.GetVisits;

public class GetVisitsQuery : IRequest<Response<VisitDetail>>
{
    public string VisitorName { get; set; }
    public string VisitorEmail { get; set; }
    public string VisitorCompany { get; set; }
    public string Employee { get; set; }
    public string Company { get; set; }
}