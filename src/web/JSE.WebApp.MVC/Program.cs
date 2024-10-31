using JSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllersWithViews();
builder.Services.AddIdentityConfiguration();
builder.Services.AddMvcConfiguration(configuration);
builder.Services.RegisterServices(configuration);

var app = builder.Build();
var environment = app.Environment;

configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, false)
        .AddJsonFile($@"appsettings.{builder.Environment.EnvironmentName}.json", false, false)
        .AddCommandLine(args)
        .AddEnvironmentVariables()
        .AddUserSecrets(typeof(Program).Assembly).Build();

app.UseMvcConfiguration(environment);

app.Run();
