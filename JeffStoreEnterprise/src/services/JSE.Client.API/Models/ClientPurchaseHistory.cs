using JSE.Core.DomainObjects;

namespace JSE.Cliente.API.Models
{
    public class ClientPurchaseHistory : Entity
    {
        public Guid OrderId { get; private set; }
        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }        
    }
}