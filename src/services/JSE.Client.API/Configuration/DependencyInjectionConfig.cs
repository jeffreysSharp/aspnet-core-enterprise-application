using FluentValidation.Results;
using JSE.Client.API.Application.Commands;
using JSE.Client.API.Application.Events;
using JSE.Client.API.Data;
using JSE.Client.API.Data.Repository;
using JSE.Client.API.Models;
using JSE.Client.API.Services;
using JSE.Core.Mediator;
using MediatR;
using System.Reflection;

namespace JSE.Client.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHostedService<RegistroClienteIntegrationHandler>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegisterClientCommand, ValidationResult>, ClientCommandHandler>();

            services.AddScoped<INotificationHandler<ClientRegisteredEvent>, ClientEventHandler>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ClientContext>();
        }
    }
}