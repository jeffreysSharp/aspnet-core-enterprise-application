using JSE.Bff.Compras.Models;

namespace JSE.Bff.Compras.Services
{
    public interface IClienteService
    {
        Task<EnderecoDTO> ObterEndereco();
    }
}