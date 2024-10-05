using JSE.Catalogo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace JSE.Catalogo.API.Controllers
{
    [ApiController]
    public class CatalogoController : Controller
    {

        private readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet("catalogo/produtos")]
        public async Task<IEnumerable<Produto>> Index()
        {
            return await _produtoRepository.ObterTodos();
        }

        [HttpGet("catalogo/produtos/{id}")]
        public async Task<Produto> Produtodetalhe(Guid id)
        {
            return await _produtoRepository.ObterPorId(id);
        }

    }
}
