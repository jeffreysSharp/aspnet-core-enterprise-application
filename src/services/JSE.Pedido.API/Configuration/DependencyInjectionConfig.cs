using JSE.Core.Mediator;
using JSE.Pedidos.Infra.Data;
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

            // Data
            services.AddScoped<PedidosContext>();

        }
    }
}