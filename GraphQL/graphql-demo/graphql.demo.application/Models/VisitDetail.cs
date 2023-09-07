namespace graphql.demo.application.Models;

public class VisitDetail
{
    public string VisitorName { get; set; }
    public string VisitorEmail { get; set; }
    public string? VisitorCompany { get; set; }
    public string VisitingCompany { get; set; }
    public string VisitingEmployee { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}
