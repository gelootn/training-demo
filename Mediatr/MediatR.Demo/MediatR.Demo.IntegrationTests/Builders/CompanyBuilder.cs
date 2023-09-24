using MediatR.Demo.Dal.Entities;

namespace MediatR.Demo.IntegrationTests.Builders;

public static class CompanyBuilder
{
    public static Dal.Entities.Company CreateDefaultCompany(string name = "Default Company")
    {
        return new Dal.Entities.Company
        {
            Name = name,
            Deleted = false
        };
    }

    public static Dal.Entities.Company WithEmployee(this Dal.Entities.Company company,
        string name = "Default Employee",
        string email = "default.employee@company.com",
        string function = "employee"
        )
    {
        if (company.Employees == null)
            company.Employees = new List<Employee>();

        company.Employees.Add(new Employee
        {
            Name = name,
            Email = email,
            Function = function,
            Deleted = false
        });

        return company;
    }
    
    
}