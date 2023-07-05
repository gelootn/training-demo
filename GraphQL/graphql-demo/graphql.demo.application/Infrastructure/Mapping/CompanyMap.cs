using graphql.demo.application.Commands.Company.AddCompany;
using graphql.demo.application.Commands.Company.UpdateCompany;
using graphql.demo.application.Models;
using graphql.demo.persistence.Entities;

namespace graphql.demo.application.Infrastructure.Mapping;

public class CompanyMap : Profile
{
    public CompanyMap()
    {
        CreateMap<AddCompanyCommand, Company>();
        CreateMap<UpdateCompanyCommand, Company>();
        CreateMap<Company, CompanyDetail>().ReverseMap();
    }
}