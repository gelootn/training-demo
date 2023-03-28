using Dapper.Demo.Bll.Models;
using Dapper.Demo.Framework;
using MediatR;

namespace Dapper.Demo.Bll.Queries.Visit.GetOpenVisits;

public class GetOpenVisitsQuery : IRequest<Response<VisitDetail>>
{
    
}