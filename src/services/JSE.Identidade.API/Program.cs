using JSE.Identidade.API.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, false)
        .AddJsonFile($@"appsettings.{builder.Environment.EnvironmentName}.json", false, false)
        .AddCommandLine(args)
        .AddEnvironmentVariables()
        .AddUserSecrets(typeof(Program).Assembly).Build();

builder.Services.AddIdentityConfiguration(configuration);
builder.Services.AddApiConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddMessageBusConfiguration(configuration);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
var environment = app.Environment;

app.UseSwaggerConfiguration();
app.UseApiConfiguration(environment);



app.Run();
