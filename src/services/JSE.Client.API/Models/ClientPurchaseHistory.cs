using JSE.Core.DomainObjects;

namespace JSE.Client.API.Models
{
    public class ClientPurchaseHistory : Entity
    {
        public Guid OrderId { get; private set; }
        public Guid ClientId { get; private set; }
        public Clients Client { get; private set; }


        public ClientPurchaseHistory() { }

        public ClientPurchaseHistory(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}