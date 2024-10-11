using FluentValidation.Results;
using JSE.Client.API.Application.Events;
using JSE.Client.API.Models;
using JSE.Core.DomainObjects;
using JSE.Core.Messages;
using MediatR;

namespace JSE.Client.API.Application.Commands
{
    public class ClientCommandHandler : CommandHandler,
        IRequestHandler<RegisterClientCommand, ValidationResult>
    {
        private readonly IClientRepository _clientRepository;

        public ClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ValidationResult> Handle(RegisterClientCommand message, CancellationToken cancellationToken)
        {
            if(!message.IsValid()) return message.ValidationResult;

            var client = new Clients(message.Id, message.FirstName, message.LastName, message.Surname, message.GenderId, 
                message.Email, message.Phone, message.BirthdayDate, message.DocumentNumber);

            var clientExists = await _clientRepository.GetByDocument(client.DocumentNumber.DocumentNumber);

            if (clientExists != null)
            {
                AddError("Este CPF já está em uso.");
                return ValidationResult;
            }
            _clientRepository.Add(client);

            client.AddEvent(new ClientRegisteredEvent(message.Id, message.FirstName, message.LastName,
                message.Surname, message.GenderId, message.Email, message.Phone, message.BirthdayDate,
                message.DocumentNumber));

            return await PersistData(_clientRepository.UnitOfWork);
        }
    }
}
