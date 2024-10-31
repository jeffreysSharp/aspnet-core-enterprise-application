using JSE.WebAPI.Core.User;
using JSE.WebApp.MVC.Extensions;
using JSE.WebApp.MVC.Services;
using JSE.WebApp.MVC.Services.Handlers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Polly;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IAspNetUser, AspNetUser>();

#region HttpServices

builder.Services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

builder.Services.AddHttpClient<IAutenticacaoService, AutenticacaoService>()
                    .AddPolicyHandler(PollyExtensions.EsperarTentar())
                    .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));


builder.Services.AddHttpClient<ICatalogoService, CatalogoService>()
    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
        .AddPolicyHandler(PollyExtensions.EsperarTentar())
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

builder.Services.AddHttpClient<ICarrinhoService, CarrinhoService>()
    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
    .AddPolicyHandler(PollyExtensions.EsperarTentar())
    .AddTransientHttpErrorPolicy(
        p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));


#endregion

var configuration = builder.Configuration.GetSection("AutenticacaoUrl");
builder.Services.Configure<AppSettings>(configuration);


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/acesso-negado";
                });



var app = builder.Build();


builder.Configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, false)
        .AddJsonFile($@"appsettings.{builder.Environment.EnvironmentName}.json", false, false)
        .AddCommandLine(args)
        .AddEnvironmentVariables()
        .AddUserSecrets(typeof(Program).Assembly).Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}
//else
//{
//    app.UseExceptionHandler("/erro/500");
//    app.UseStatusCodePagesWithRedirects("/erro/{0}");
//    app.UseHsts();
//}

app.UseExceptionHandler("/erro/500");
app.UseStatusCodePagesWithRedirects("/erro/{0}");
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

var supportedCultures = new[] { new CultureInfo("pt-BR") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseAuthorization();
app.UseAuthentication();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Catalogo}/{action=Index}/{id?}");

app.Run();