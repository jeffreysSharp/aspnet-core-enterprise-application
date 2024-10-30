
using FluentValidation.Results;
using JSE.Client.API.Application.Commands;
using JSE.Core.Integration;
using JSE.Core.Mediator;
using JSE.MessageBus;

namespace JSE.Client.API.Services
{
    public class RegistroClienteIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistroClienteIntegrationHandler(IServiceProvider serviceProvider, IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(async request =>
                await RegistrarCliente(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            SetResponder();           

            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e)
        {
            SetResponder();
        }

        private async Task<ResponseMessage> RegistrarCliente(UsuarioRegistradoIntegrationEvent message)
        {
            var clienteCommand = new RegisterClientCommand(message.Id, message.FirstName, message.LastName, message.Surname, message.GenderId,
                message.Email, message.Phone, message.BirthdayDate, message.DocumentNumber);

            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.SendCommand(clienteCommand);
            }
            
            return new ResponseMessage(sucesso);
        }
    }
}
