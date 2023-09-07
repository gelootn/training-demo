using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Environment.Shell;

namespace My.Module.First;

public class Startup
{
    public void Configure(IEndpointRouteBuilder endPoints, IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(cfg =>
            {
                cfg.SwaggerEndpoint("mod1/swagger/v1/swagger.json", "My.Module.First");
            });

        
        endPoints.MapGet("mod1/hello", () => "Hello World!")
        .WithDisplayName("Module 1 - Hello")
        .WithName("Module 1 - Hello")
        .WithOpenApi();

        /*endPoints.MapGet("mod1/info",   (context) =>
        {
            var shellSettings = context.RequestServices.GetRequiredService<ShellSettings>();
            return Results.Ok(shellSettings);
        })
        .WithName("Module 1 - Info")
        .WithOpenApi();*/
    }
}