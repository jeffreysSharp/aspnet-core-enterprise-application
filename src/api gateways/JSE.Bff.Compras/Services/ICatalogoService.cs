using JSE.Bff.Compras.Models;

namespace JSE.Bff.Compras.Services
{
    public interface ICatalogoService
    {
        Task<ItemProdutoDTO> ObterPorId(Guid id);
    }
}