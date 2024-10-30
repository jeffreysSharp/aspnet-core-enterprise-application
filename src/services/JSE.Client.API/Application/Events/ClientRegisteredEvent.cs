using JSE.Client.API.Models;
using JSE.Core.DomainObjects;
using JSE.Core.Messages;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSE.Client.API.Application.Events
{
    public class ClientRegisteredEvent : Event
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Surname { get; private set; }
        public Guid GenderId { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime BirthdayDate { get; private set; }
        public string DocumentNumber { get; private set; }

        public ClientRegisteredEvent(Guid id, string firstName, string lastName, string surname, Guid genderId, string email, string phone, DateTime birthdayDate, string documentNumber)
        {
            AggregateId = id;
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Surname = surname;
            GenderId = genderId;
            Email = email;
            Phone = phone;
            BirthdayDate = birthdayDate;
            DocumentNumber = documentNumber;
        }
    }
}
