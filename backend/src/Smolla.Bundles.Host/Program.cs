using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, _, loggerConfig) =>
{
    loggerConfig
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console();
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

WebApplication app = builder.Build();

app.UseSerilogRequestLogging();
app.UseRouting();
app.MapControllers();

app.Run();

/// <summary>
/// Marker type so <c>WebApplicationFactory&lt;Program&gt;</c> can boot the host
/// from the integration tests project.
/// </summary>
public partial class Program;
