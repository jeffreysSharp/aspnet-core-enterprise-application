﻿using JSE.Catalogo.API.Extensions;
using JSE.Catalogo.API.Models;
using JSE.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JSE.Catalogo.API.Controllers
{
    [Authorize]
    public class CatalogoController : MainController
    {

        private readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [AllowAnonymous]
        [HttpGet("catalogo/produtos")]
        public async Task<IEnumerable<Produto>> Index()
        {
            return await _produtoRepository.ObterTodos();
        }


        [ClaimsAuthorize("Catalogo", "Ler")]
        [HttpGet("catalogo/produtos/{id}")]
        public async Task<Produto> Produtodetalhe(Guid id)
        {
            return await _produtoRepository.ObterPorId(id);
        }

    }
}
