using JSE.Core.Mediator;
using JSE.WebAPI.Core.Controllers;

namespace JSE.Client.API.Controllers
{
    public class ClientController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        public ClientController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }
    }
}
