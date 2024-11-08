using JSE.Clientes.API.Models;
using JSE.Core.Mediator;
using JSE.WebAPI.Core.Controllers;
using JSE.WebAPI.Core.User;

namespace JSE.Clientes.API.Controllers
{
    public class ClientController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;

        public ClientController(IClienteRepository clienteRepository, IMediatorHandler mediator, IAspNetUser user)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
            _user = user;
        }
    }
}
