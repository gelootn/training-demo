using MediatR.Demo.Dal.Entities;

namespace MediatR.Demo.IntegrationTests.Builders;

public static class VisitBuilder
{
    public static Visitor CreateDefaultVisitor(string name = "Default Visitor", string email = "visitor@email.com",
        string company = "visitor company")
    {
        return new Visitor
        {
            Name = name,
            Email = email,
            Company = company
        };
    }
    
    //public static Visit
    
}