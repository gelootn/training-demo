using graphql.demo.application.Infrastructure.Extensions;
using graphql.demo.application.Queries;
using graphql.demo.persistence.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBusinessLayer(builder.Configuration.GetConnectionString("demo"));
builder.Services.AddGraphQLServer()
    .AddFiltering()
    .AddQueryType<VisitQueryType>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();
app.Run();