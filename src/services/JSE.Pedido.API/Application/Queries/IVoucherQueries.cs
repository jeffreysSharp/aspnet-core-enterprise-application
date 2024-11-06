using JSE.Pedido_API.Application.DTO;

namespace JSE.Pedido_API.Application.Queries
{
    public interface IVoucherQueries
    {
        Task<VoucherDTO> ObterVoucherPorCodigo(string codigo);
    }
}
