using JSE.Core.Utils;
using JSE.MessageBus;
using JSE.Pagamentos.API.Services;

namespace JSE.Pagamentos.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<PagamentoIntegrationHandler>();
        }
    }
}