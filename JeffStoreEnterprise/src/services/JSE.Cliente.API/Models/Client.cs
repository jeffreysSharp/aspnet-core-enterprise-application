using JSE.Core.DomainObjects;

namespace JSE.Cliente.API.Models
{
    public class Client : Entity, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Surname {  get; private set; }
        public Guid GenderId { get; set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime BirthdayDate { get; private set; }
        public string Document { get; private set; }
        public bool IsRemoved { get; private set; }
        public List<ClientAddress> Addresses { get; private set; }
        public List<ClientPurchaseHistory> PurchaseHistories { get; private set; }

        public Client()  { }

        public Client(string firstName, string lastName, Guid genderId, string email, string phone, DateTime birthdayDate, string document)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            BirthdayDate = birthdayDate;
            Document = document;
            IsRemoved = false;
        }
    }
}
