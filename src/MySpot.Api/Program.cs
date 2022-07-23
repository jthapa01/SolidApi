using Microsoft.Extensions.Options;
using MySpot.Api;
using MySpot.Application;
using MySpot.Application.Abstractions;
using MySpot.Application.Commands;
using MySpot.Application.DTO;
using MySpot.Application.Queries;
using MySpot.Core;
using MySpot.Core.ValueObjects;
using MySpot.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Host.UseSerilog((context, LoggerConfiguration) =>
{
    LoggerConfiguration.WriteTo
        .Console()
        .WriteTo
        .File("logs.txt")
        .WriteTo
        .Seq("http://localhost:5341");
});

var app = builder.Build();
//middleware
app.UseInfrastructure();
app.MapGet("api", (IOptions<AppOptions> options) => Results.Ok(options.Value.Name));
app.UseUsersApi();
app.Run();
