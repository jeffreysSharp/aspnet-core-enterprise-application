using JSE.Core.DomainObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSE.Client.API.Models
{
    public class Clients : Entity, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Surname { get; private set; }
        [ForeignKey("Gender")]
        public Guid GenderId { get; private set; }
        public virtual Gender Gender { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime BirthdayDate { get; private set; }
        public ClientDocument DocumentNumber { get; private set; }
        public bool IsRemoved { get; private set; }
        public List<ClientAddress> Addresses { get; private set; }
        public List<ClientPurchaseHistory> PurchaseHistories { get; private set; }

        protected Clients() { }

        public Clients(Guid id, string firstName, string lastName, string surname, Guid genderId, string email, string phone, DateTime birthdayDate, string documentNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Surname = surname;
            GenderId = genderId;
            Email = new Email(email);
            Phone = phone;
            BirthdayDate = birthdayDate;
            DocumentNumber = new ClientDocument(documentNumber);
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
