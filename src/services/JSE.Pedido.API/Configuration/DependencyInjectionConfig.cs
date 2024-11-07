using FluentValidation.Results;
using JSE.Core.Mediator;
using JSE.Pedido_API.Application.Events;
using JSE.Pedido_API.Application.Queries;
using JSE.Pedidos.API.Application.Commands;
using JSE.Pedidos.API.Application.Queries;
using JSE.Pedidos.Domain;
using JSE.Pedidos.Domain.Pedidos;
using JSE.Pedidos.Infra.Data;
using JSE.Pedidos.Infra.Data.Repository;
using JSE.WebAPI.Core.User;
using MediatR;
using NSE.Pedidos.API.Application.Commands;
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
            services.AddScoped<IRequestHandler<AdicionarPedidoCommand, ValidationResult>, PedidoCommandHandler>();

            // Events
            services.AddScoped<INotificationHandler<PedidoRealizadoEvent>, PedidoEventHandler>();

            // Application
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherQueries, VoucherQueries>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();

            // Data
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<PedidosContext>();

        }
    }
}