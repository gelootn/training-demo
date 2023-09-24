using System.Net.Http.Json;
using FluentAssertions;
using MediatR.Demo.Dal.Database;
using MediatR.Demo.EndPoint.Models;
using MediatR.Demo.IntegrationTests.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MediatR.Demo.IntegrationTests.Company;

public class VisitEndpointTests : IntegrationTest
{
    public VisitEndpointTests(ApiWebApplicationFactory fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task Signin_With_Unknown_Visitor_Should_Create_Visitor_And_Visit()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<DemoDbContext>();

            var company = CompanyBuilder.CreateDefaultCompany()
                .WithEmployee();
            
            await db.Companies.AddAsync(company);
            await db.SaveChangesAsync();

            var postModel = new StartVisitModel("Vistor Name", "visitor@email.com", "Visitor Company",
                company.Employees.First().Id, company.Id);
            
            var result = await _client.PostAsJsonAsync("api/visits/signin", postModel);

            var visitors = await db.Visitors.ToListAsync();
            var visits = await db.Visits.ToListAsync();

            visits.Count.Should().Be(1);
            visitors.Count.Should().Be(1);

        }
    }
}