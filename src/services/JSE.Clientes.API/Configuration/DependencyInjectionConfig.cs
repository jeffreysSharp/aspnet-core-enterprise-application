using FluentValidation.Results;
using JSE.Clientes.API.Application.Commands;
using JSE.Clientes.API.Application.Events;
using JSE.Clientes.API.Data;
using JSE.Clientes.API.Data.Repository;
using JSE.Clientes.API.Models;
using JSE.Clientes.API.Services;
using JSE.Core.Mediator;
using MediatR;
using System.Reflection;

namespace JSE.Clientes.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHostedService<RegistroClienteIntegrationHandler>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();

            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ClienteContext>();
        }
    }
}