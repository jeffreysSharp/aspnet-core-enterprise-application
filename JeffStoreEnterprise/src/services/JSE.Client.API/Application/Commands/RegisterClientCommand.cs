using FluentValidation;
using JSE.Core.Messages;

namespace JSE.Client.API.Application.Commands
{
    public class RegisterClientCommand : Command
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

        public RegisterClientCommand(Guid id, string firstName, string lastName, string surname, Guid genderId, string email, string phone, DateTime birthdayDate, string documentNumber)
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

        public override bool IsValid()
        {
            ValidationResult = new RegisterClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class RegisterClientValidation : AbstractValidator<RegisterClientCommand>
        {
            public RegisterClientValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do Cliente inválido");

                RuleFor(c => c.FirstName)
                    .NotEmpty()
                    .WithMessage("O Primeiro Nome não foi informado");

                RuleFor(c => c.LastName)
                    .NotEmpty()
                    .WithMessage("O Sobrenome não foi informado");

                RuleFor(c => c.DocumentNumber)
                    .Must(IsValidDocument)
                    .WithMessage("CPF inválido");

                RuleFor(c => c.Email)
                    .Must(IsValidEmail)
                    .WithMessage("E-mail inválido");
            }

            protected static bool IsValidDocument(string documentNumber)
            {
                return Core.DomainObjects.ClientDocument.ValidarCpf(documentNumber);
            }

            protected static bool IsValidEmail(string email)
            {
                return Core.DomainObjects.Email.Validate(email);
            }
        }
    }
}
