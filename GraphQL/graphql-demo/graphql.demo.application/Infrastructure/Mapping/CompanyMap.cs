using graphql.demo.application.Commands.Company.AddCompany;
using graphql.demo.application.Commands.Company.UpdateCompany;

namespace graphql.demo.application.Infrastructure.Mapping;

public class CompanyMap : Profile
{
    public CompanyMap()
    {
        CreateMap<AddCompanyCommand, Company>();
        CreateMap<UpdateCompanyCommand, Company>();
        CreateMap<Company, CompanyDetail>().ReverseMap();
    }

    public static IConfigurationProvider GetConfiguration()
    {
        return new MapperConfiguration(cfg =>
            {
                cfg.CreateProjection<Company, CompanyDetail>();
                cfg.CreateProjection<Employee, EmployeeDetail>();
            });
    }
}