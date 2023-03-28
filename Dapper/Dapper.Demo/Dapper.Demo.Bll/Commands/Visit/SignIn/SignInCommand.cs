using Dapper.Demo.Bll.Infrastructure;
using Dapper.Demo.Framework;
using MediatR;

namespace Dapper.Demo.Bll.Commands.Visit.SignIn;

public class SignInCommand : IRequest<Response<bool>>, IValidatable
{
    public SignInCommand(string visitorName, string visitorEmail, string visitorCompany, int companyId, int employeeId)
    {
        VisitorName = visitorName;
        VisitorEmail = visitorEmail;
        VisitorCompany = visitorCompany;
        CompanyId = companyId;
        EmployeeId = employeeId;
    }

    public string VisitorName { get;  }
    public string VisitorEmail { get;  }
    public string VisitorCompany { get;  }
    public int CompanyId { get;  }
    public int EmployeeId { get;  }
}