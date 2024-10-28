
using EasyNetQ;
using FluentValidation.Results;
using JSE.Client.API.Application.Commands;
using JSE.Core.Integration;
using JSE.Core.Mediator;

namespace JSE.Client.API.Services
{
    public class RegistroClienteIntegrationHandler : BackgroundService
    {
        private IBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistroClienteIntegrationHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus("host=localhost:5672");

            _bus.Rpc.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(async request =>
                new ResponseMessage(await RegistrarCliente(request)));

            return Task.CompletedTask;
        }

        private async Task<ValidationResult> RegistrarCliente(UsuarioRegistradoIntegrationEvent message)
        {
            var clienteCommand = new RegisterClientCommand(message.Id, message.FirstName, message.LastName, message.Surname, message.GenderId,
                message.Email, message.Phone, message.BirthdayDate, message.DocumentNumber);

            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.SendCommand(clienteCommand);
            }
            
            return sucesso;
        }
    }
}
