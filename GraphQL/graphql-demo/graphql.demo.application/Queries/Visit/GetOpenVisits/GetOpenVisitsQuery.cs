using graphql.demo.application.Models;
using MediatR;

namespace graphql.demo.application.Queries.Visit.GetOpenVisits;

public class GetOpenVisitsQuery : IRequest<Response<VisitDetail>>
{
    
}