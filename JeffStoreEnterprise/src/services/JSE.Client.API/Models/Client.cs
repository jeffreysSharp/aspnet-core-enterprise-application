using Jse.Core.DomainObjects;
using JSE.Core.DomainObjects;

namespace JSE.Cliente.API.Models
{
    public class Client : Entity, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Surname { get; private set; }
        public Guid GenderId { get; set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime BirthdayDate { get; private set; }
        public ClientDocument Document { get; private set; }
        public bool IsRemoved { get; private set; }
        public List<ClientAddress> Addresses { get; private set; }
        public List<ClientPurchaseHistory> PurchaseHistories { get; private set; }

        public Client() { }

        public Client(Guid id, string firstName, string lastName, Guid genderId, string email, string phone, DateTime birthdayDate, string document)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = new Email(email);
            Phone = phone;
            BirthdayDate = birthdayDate;
            Document = new ClientDocument(document);
            IsRemoved = false;
        }

        public void ChangeEmail(string email)
        {
            Email = new Email(email);
        }

        //TODO
        //public void AssignAddress(ClientAddress address)
        //{
        //    ClientAddress = address;

        //}

    }
}
