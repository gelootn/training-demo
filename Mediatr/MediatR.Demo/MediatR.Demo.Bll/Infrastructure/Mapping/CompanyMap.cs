using AutoMapper;
using MediatR.Demo.Bll.Commands.Company.AddCompany;
using MediatR.Demo.Bll.Commands.Company.UpdateCompany;
using MediatR.Demo.Bll.Models;
using MediatR.Demo.Dal.Entities;

namespace MediatR.Demo.Bll.Infrastructure.Mapping;

public class CompanyMap : Profile
{
    public CompanyMap()
    {
        CreateMap<AddCompanyCommand, Company>();
        CreateMap<UpdateCompanyCommand, Company>();
        CreateMap<Company, CompanyDetail>().ReverseMap();
    }
}