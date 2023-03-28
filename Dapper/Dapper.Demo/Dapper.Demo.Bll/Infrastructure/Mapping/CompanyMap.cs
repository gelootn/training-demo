using AutoMapper;
using Dapper.Demo.Bll.Commands.Company.AddCompany;
using Dapper.Demo.Bll.Commands.Company.UpdateCompany;
using Dapper.Demo.Bll.Models;
using Dapper.Demo.Dal.Entities;

namespace Dapper.Demo.Bll.Infrastructure.Mapping;

public class CompanyMap : Profile
{
    public CompanyMap()
    {
        CreateMap<AddCompanyCommand, Company>();
        CreateMap<UpdateCompanyCommand, Company>();
        CreateMap<Company, CompanyDetail>().ReverseMap();
    }
}