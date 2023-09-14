namespace MediatR.Demo.IntegrationTests.Infrastructure;

[Collection("Integration Tests")]
public abstract class IntegrationTest : IAsyncLifetime
{
    protected readonly ApiWebApplicationFactory _factory;
    protected readonly HttpClient _client;
    private readonly Func<Task> _resetDatabase;


    protected IntegrationTest(ApiWebApplicationFactory fixture)
    {
        _factory = fixture;
        _client = fixture.HttpClient; _factory.CreateClient();      
        _resetDatabase = _factory.ResetDatabaseAsync;        
    }

    public async Task DisposeAsync() => await _resetDatabase();

    public Task InitializeAsync() => Task.CompletedTask;
}