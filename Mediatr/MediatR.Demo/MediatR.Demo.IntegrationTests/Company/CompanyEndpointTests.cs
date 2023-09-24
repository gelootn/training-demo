using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using MediatR.Demo.Bll.Queries.Company.GetAllCompanies;
using MediatR.Demo.Dal.Database;
using MediatR.Demo.Dal.Entities;
using MediatR.Demo.EndPoint.Models;
using MediatR.Demo.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MediatR.Demo.IntegrationTests.Company;

public class CompanyEndpointTests : IntegrationTest
{
    public CompanyEndpointTests(ApiWebApplicationFactory fixture) : base(fixture)
    {
        
    }
    
    [Fact]
    public async Task Get_Companies_ReturnsSuccessStatusCode()
    {
        // Act
        var response = await _client.GetFromJsonAsync<GetAllCompaniesQueryResult>("/api/companies");
        
        // Assert
        response.Should().NotBeNull();
    }
    
    [Fact]
    public async Task Get_Companies_Should_Return_Seeded_Data()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<DemoDbContext>();

            await db.Companies.AddAsync(new Dal.Entities.Company
            {
                Name = "Test Company",
                Deleted = false
            });
            await db.SaveChangesAsync();
            
            var response = await _client.GetFromJsonAsync<GetAllCompaniesQueryResult>("/api/companies");
            // Assert
            response.Should().NotBeNull();
            response.Companies.Should().HaveCount(1);
        }
    }

    [Fact]
    public async Task Post_Valid_Company_Should_Add_A_Company()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<DemoDbContext>();

            var postModel = new CompanyModel(0, "My Company");

            var result = await _client.PostAsJsonAsync("api/companies", postModel);

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var companies = await db.Companies.ToListAsync();
            companies.Count.Should().Be(1);
        }
    }
    
    [Fact]
    public async Task Post_InValid_Company_Should_Not_Add_A_Company()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<DemoDbContext>();

            var postModel = new CompanyModel(0, "");

            var result = await _client.PostAsJsonAsync("api/companies", postModel);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var companies = await db.Companies.ToListAsync();
            companies.Count.Should().Be(0);
        }
    }
    
    [Fact]
    public async Task Put_Valid_Company_Should_Update_That_Company()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<DemoDbContext>();
            var existingCompany = new Dal.Entities.Company()
            {
                Name = "Test Company"
            };
            await db.Companies.AddAsync(existingCompany);
            await db.SaveChangesAsync();

            var putModel = new CompanyModel(existingCompany.Id, "new name");

            var result = await _client.PutAsJsonAsync($"api/companies/{existingCompany.Id}", putModel);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var companies = await db.Companies.AsNoTracking().ToListAsync();
            companies.Count.Should().Be(1);
            companies[0].Name.Should().Be("new name");
        }
    }
    
    [Fact]
    public async Task Delete_Valid_Company_Should_Remove_That_Company()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<DemoDbContext>();
            var existingCompany = new Dal.Entities.Company()
            {
                Name = "Test Company"
            };
            await db.Companies.AddAsync(existingCompany);
            await db.SaveChangesAsync();

            var putModel = new CompanyModel(existingCompany.Id, "new name");

            var result = await _client.DeleteAsync($"api/companies/{existingCompany.Id}");

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var companies = await db.Companies.AsNoTracking().ToListAsync();
            companies.Count.Should().Be(0);
            
        }
    }
    
    [Fact]
    public async Task Post_Employee_Should_Add_That_Employee_To_The_Company()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<DemoDbContext>();
            var existingCompany = new Dal.Entities.Company()
            {
                Name = "Test Company"
            };
            await db.Companies.AddAsync(existingCompany);
            await db.SaveChangesAsync();
            
            var employeeModel = new EmployeeModel(0, "Employee", "info@company.com", "CEO", existingCompany.Id);
    

            var result = await _client.PostAsJsonAsync($"api/companies/{existingCompany.Id}/employee/", employeeModel);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var companies = await db.Companies.Include(x=> x.Employees).AsNoTracking().ToListAsync();
            companies.Count.Should().Be(1);
            companies[0].Employees.Should().HaveCount(1);
            
        }
    }
    
    [Fact]
    public async Task Put_Employee_Should_Update_That_Employee()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<DemoDbContext>();
            var existingCompany = new Dal.Entities.Company()
            {
                Name = "Test Company",
                Employees = new List<Employee>
                {
                    new()
                    {
                        Name = "Employee 1",
                        Deleted = false,
                        Email = "info@company.be",
                        Function = "CIO"
                    }
                }
            };
            await db.Companies.AddAsync(existingCompany);
            await db.SaveChangesAsync();
            
            var employeeModel = new EmployeeModel(1, "name", "email@company.com", "CEO", existingCompany.Id);
    

            var result = await _client.PutAsJsonAsync($"api/companies/{existingCompany.Id}/employee/{1}", employeeModel);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var companies = await db.Companies.AsNoTracking().Include(x=> x.Employees).AsNoTracking().ToListAsync();
            companies.Count.Should().Be(1);
            
            var company = companies.First();
            company.Employees.Should().HaveCount(1);
            
            var employee = company.Employees.First();
            employee.Name.Should().Be("name");
            employee.Email.Should().Be("email@company.com");
            employee.Function.Should().Be("CEO");
            
        }
    }
    
}