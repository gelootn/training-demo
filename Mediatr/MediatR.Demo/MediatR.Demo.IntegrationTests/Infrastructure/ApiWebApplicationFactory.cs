using MediatR.Demo.Dal.Database;
using MediatR.Demo.IntegrationTests.Infrastructure.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using Respawn.Graph;
using Testcontainers.MsSql;

namespace MediatR.Demo.IntegrationTests.Infrastructure;

public class ApiWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MsSqlContainer _dbContainer;
    private Respawner _respawner;
    private string _connectionString;
    
    public HttpClient HttpClient { get; private set; } = default!;
    public IConfiguration Configuration { get; private set; } = default!;
    
    public ApiWebApplicationFactory()
    {
        _dbContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithCleanUp(true)
            .Build();
    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(config =>
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("testsettings.json")
                .Build();

            config.AddConfiguration(Configuration);
        });

        builder.ConfigureTestServices(services =>
        {
            // Remove AppDbContext
            services.RemoveDbContext<DemoDbContext>();

            // Add DB context pointing to test container
            services.AddDbContext<DemoDbContext>(options => { options.UseSqlServer(_dbContainer.GetConnectionString()); });

            // Ensure schema gets created
            services.EnsureDbCreated<DemoDbContext>();
        });
    }
    
    public async Task ResetDatabaseAsync()
    {
        using var scope = Services.CreateScope();

        var scopedServices = scope.ServiceProvider;
        var db = scopedServices.GetRequiredService<DemoDbContext>();

        await db.Companies.ToListAsync();
        try
        {
            await _respawner.ResetAsync(_connectionString);
        }
        catch
        {
            var test = _respawner.DeleteSql;
            throw;
        }
        await db.Companies.ToListAsync();
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
        _connectionString = _dbContainer.GetConnectionString();
        HttpClient = CreateClient();

        _respawner = await Respawner.CreateAsync(_connectionString, new RespawnerOptions
        {
            TablesToInclude = new Table[]
            {
                new Table("dbo", "Companies"),
                new Table("dbo", "Employees"),
                new Table("dbo", "Visitors"),
                new Table("dbo", "Visits")
                
            },
            DbAdapter = DbAdapter.SqlServer
        });
    }

    public async Task DisposeAsync() => await _dbContainer.DisposeAsync();
}