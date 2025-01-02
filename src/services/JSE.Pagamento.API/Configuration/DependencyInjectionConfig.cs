using JSE.Pagamentos.API.Data;
using JSE.Pagamentos.API.Data.Repository;
using JSE.Pagamentos.API.Models;
using JSE.Pagamentos.API.Services;
using JSE.Pagamentos.CardAntiCorruption;
using JSE.Pagamentos.Facade;
using JSE.WebAPI.Core.User;

namespace JSE.Pagamentos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IPagamentoFacade, PagamentoCartaoCreditoFacade>();

            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<PagamentosContext>();
        }
    }
}