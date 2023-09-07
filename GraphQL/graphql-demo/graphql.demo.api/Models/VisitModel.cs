namespace graphql.demo.api.Models;

public record VisitModel(string VisitorName, string VisitorEmail, string VisitorCompany, DateTime Start, DateTime? Stop, string Employee, string Company);
