using JSE.WebApp.MVC.Models;

namespace JSE.WebApp.MVC.Services
{
    public interface ICarrinhoService
    {
        Task<CarrinhoViewModel> ObterCarrinho();
        Task<ResponseResultViewModel> AdicionarItemCarrinho(ItemProdutoViewModel produto);
        Task<ResponseResultViewModel> AtualizarItemCarrinho(Guid produtoId, ItemProdutoViewModel produto);
        Task<ResponseResultViewModel> RemoverItemCarrinho(Guid produtoId);
    }
}