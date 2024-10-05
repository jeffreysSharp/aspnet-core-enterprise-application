using JSE.Catalogo.API.Data;
using JSE.Catalogo.API.Data.Repository;
using JSE.Catalogo.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<CatalogoContext>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CatalogoContext>(x => x.UseSqlServer(connectionString));

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

//builder.Services.AddSwaggerGen(c =>
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "JeffStore Enterprise Identity API",
//        Description = "Esta é a API da JeffStore Enterprise Applications",
//        Contact = new OpenApiContact() { Name = "Jeferson Almeida", Email = "jefferson_qi3@hotmail.com" },
//        License = new OpenApiLicense()
//        {
//            Name = "MIT",
//            Url = new Uri("https://opensource.org/licenses/MIT")
//        }
//    })
//);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
