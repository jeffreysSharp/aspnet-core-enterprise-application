using Microsoft.EntityFrameworkCore;
using JSE.Catalogo.API.Data;
using Microsoft.OpenApi.Models;
using System.Reflection;
using JSE.Core.Mediator;
using MediatR;
using JSE.Client.API.Application.Commands;
using FluentValidation.Results;
using JSE.Client.API.Models;
using JSE.Client.API.Data.Repository;
using JSE.Client.API.Application.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ClientContext>(x => x.UseSqlServer(connectionString));


builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();
builder.Services.AddScoped<IRequestHandler<RegisterClientCommand, ValidationResult>, ClientCommandHandler>();

builder.Services.AddScoped<INotificationHandler<ClientRegisteredEvent>, ClientEventHandler>();

builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddScoped<ClientContext>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "JeffStore Enterprise Client API",
        Description = "Esta é a API da JeffStore Enterprise Applications",
        Contact = new OpenApiContact() { Name = "Jeferson Almeida", Email = "jefferson_qi3@hotmail.com" },
        License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT desta maneira: Bearer {seu token}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


var app = builder.Build();

builder.Configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, false)
        .AddJsonFile($@"appsettings.{builder.Environment.EnvironmentName}.json", false, false)
        .AddCommandLine(args)
        .AddEnvironmentVariables()
        .AddUserSecrets(typeof(Program).Assembly).Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
