using JSE.Client.API.Application.Commands;
using JSE.Core.Mediator;
using JSE.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace JSE.Client.API.Controllers
{
    public class ClientController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        public ClientController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
           var result = await _mediatorHandler.SendCommand(new RegisterClientCommand(Guid.NewGuid(), "Jeferson", "Almeida",
                "Jé", Guid.Parse("B91AFC01-B0B7-4B5E-98BD-885F2BE32780"), "jefferson_qi3@hotmail.com", "11997541210", 
                DateTime.Now, "29492873877"));

            return CustomResponse(result);  
        }
    }
}
