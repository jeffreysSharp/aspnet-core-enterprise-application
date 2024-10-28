namespace JSE.Core.Integration
{
    public class UsuarioRegistradoIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Surname { get; private set; }
        public Guid GenderId { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime BirthdayDate { get; private set; }
        public string DocumentNumber { get; private set; }

        public UsuarioRegistradoIntegrationEvent(Guid id, string firstName, string lastName, string surname, Guid genderId, string email, string phone, DateTime birthdayDate, string documentNumber)
        {
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
