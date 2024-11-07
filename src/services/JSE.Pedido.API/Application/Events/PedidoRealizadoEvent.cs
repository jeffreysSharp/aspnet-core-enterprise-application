using JSE.Core.Messages;

namespace JSE.Pedido_API.Application.Events
{
    public class PedidoRealizadoEvent : Event
    {
        public Guid PedidoId { get; set; }
        public Guid ClienteId { get; set; }

        public PedidoRealizadoEvent(Guid pedidoId, Guid clienteId)
        {
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }
    }
}
