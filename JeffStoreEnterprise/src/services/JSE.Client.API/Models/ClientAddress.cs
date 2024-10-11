using JSE.Core.DomainObjects;

namespace JSE.Client.API.Models
{
    public class ClientAddress : Entity
    {       
        public int AddressType { get; private set; }
        public bool IsDefaultAddress { get; private set; }
        public string Addresss { get; private set; }
        public string  Number { get;  private set; }
        public string Complement { get;  private set; }
        public string ZipCode { get;  private set; }
        public string Country { get;  private set; }
        public string City { get;  private set; }
        public string State { get;  private set; }
        public string Reference { get;  private set; }
        public Guid ClientId { get; private set; }
        public Clients Client { get; private set; }

        public ClientAddress()
        {
                
        }

        public ClientAddress(int addressType, bool isDefaultAddress, string addresss, string number, string complement, string zipCode, string country, string city, string state, string reference)
        {
            AddressType = addressType;
            IsDefaultAddress = isDefaultAddress;
            Addresss = addresss;
            Number = number;
            Complement = complement;
            ZipCode = zipCode;
            Country = country;
            City = city;
            State = state;
            Reference = reference;
        }

    }
}