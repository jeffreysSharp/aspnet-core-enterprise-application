using JSE.Core.Mediator;
using JSE.Pedido_API.Application.Queries;
using JSE.Pedidos.Domain;
using JSE.Pedidos.Infra.Data;
using JSE.Pedidos.Infra.Data.Repository;
using JSE.WebAPI.Core.User;
using System.Reflection;

namespace JSE.Pedidos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            // Commands

            // Events


            // Application
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherQueries, VoucherQueries>();

            // Data
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<PedidosContext>();

        }
    }
}