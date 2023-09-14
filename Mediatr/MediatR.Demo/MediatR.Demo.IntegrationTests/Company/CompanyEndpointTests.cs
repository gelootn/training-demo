using System.Net.Http.Json;
using FluentAssertions;
using MediatR.Demo.Bll.Queries.Company.GetAllCompanies;
using MediatR.Demo.Dal.Database;
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
            
            var connString = db.Database.GetDbConnection();
            
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
}