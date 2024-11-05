<<<<<<< HEAD
﻿using JSE.WebAPI.Core.Controllers;
=======
﻿using JSE.Bff.Compras.Services;
using JSE.WebAPI.Core.Controllers;
>>>>>>> develop
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JSE.Bff.Compras.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {
<<<<<<< HEAD
=======
        private readonly ICarrinhoService _carrinhoService;
        private readonly ICatalogoService _catalogoService;

        public CarrinhoController(ICarrinhoService carrinhoService, 
                                  ICatalogoService catalogoService)
        {
            _carrinhoService = carrinhoService;
            _catalogoService = catalogoService;
        }

>>>>>>> develop
        [HttpGet]
        [Route("compras/carrinho")]
        public async Task<IActionResult> Index()
        {
            return CustomResponse();
        }

        [HttpGet]
        [Route("compras/carrinho-quantidade")]
        public async Task<IActionResult> ObterQuantidadeCarrinho()
        {
            return CustomResponse();
        }

        [HttpPost]
        [Route("compras/carrinho/items")]
        public async Task<IActionResult> AdicionarItemCarrinho()
        {
            return CustomResponse();
        }

        [HttpPut]
        [Route("compras/carrinho/items/{produtoId}")]
        public async Task<IActionResult> AtualizarItemCarrinho()
        {
            return CustomResponse();
        }

        [HttpDelete]
        [Route("compras/carrinho/items/{produtoId}")]
        public async Task<IActionResult> RemoverItemCarrinho()
        {
            return CustomResponse();
        }
    }
}
