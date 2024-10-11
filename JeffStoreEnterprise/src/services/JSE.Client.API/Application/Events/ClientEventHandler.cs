using MediatR;

namespace JSE.Client.API.Application.Events
{
    public class ClientEventHandler : INotificationHandler<ClientRegisteredEvent>
    {
        public Task Handle(ClientRegisteredEvent notification, CancellationToken cancellationToken)
        {
            //TODO
            // Enviar evento confirmação
            return Task.CompletedTask;
        }
    }
}
