using FluentValidation.Results;
using JSE.Client.API.Models;
using JSE.Core.Messages;
using MediatR;

namespace JSE.Client.API.Application.Commands
{
    public class ClientCommandHandler : CommandHandler,
        IRequestHandler<RegisterClientCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegisterClientCommand message, CancellationToken cancellationToken)
        {
            if(!message.IsValid()) return message.ValidationResult;

            var client = new Clients(message.Id, message.FirstName, message.LastName, message.Surname, message.GenderId, 
                message.Email, message.Phone, message.BirthdayDate, message.DocumentNumber);

            // Validations
            if (true) // DocumentNumber exists
            {
                AddError("Este CPF já está em uso.");
                return ValidationResult;
            }
            // Persist
      
            

            return message.ValidationResult;
        }
    }
}
