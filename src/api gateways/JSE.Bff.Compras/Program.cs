using JSE.Bff.Compras.Configuration.Configuration;
using JSE.Bff.Compras.Configuration;
using JSE.WebAPI.Core.IdentityConfiguration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, false)
        .AddJsonFile($@"appsettings.{builder.Environment.EnvironmentName}.json", false, false)
        .AddCommandLine(args)
        .AddEnvironmentVariables()
        .AddUserSecrets(typeof(Program).Assembly).Build();

builder.Services.AddApiConfiguration(configuration);
builder.Services.AddJwtConfiguration(configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.RegisterServices();
builder.Services.AddMessageBusConfiguration(configuration);

var app = builder.Build();
var environment = app.Environment;

app.UseSwaggerConfiguration();
app.UseApiConfiguration(environment);

app.Run();