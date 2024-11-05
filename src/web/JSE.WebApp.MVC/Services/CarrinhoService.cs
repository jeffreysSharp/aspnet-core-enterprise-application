using JSE.WebApp.MVC.Extensions;
using JSE.WebApp.MVC.Models;
using Microsoft.Extensions.Options;

namespace JSE.WebApp.MVC.Services
{
    public class CarrinhoService : Service, ICarrinhoService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoService(HttpClient httpClient,
            IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);

            _httpClient = httpClient;
        }

        public async Task<CarrinhoViewModel> ObterCarrinho()
        {
            var response = await _httpClient.GetAsync("/carrinho/");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<CarrinhoViewModel>(response);
        }

        public async Task<ResponseResultViewModel> AdicionarItemCarrinho(ItemProdutoViewModel produto)
        {
            var itemContent = ObterConteudo(produto);

            var response = await _httpClient.PostAsync("/carrinho/", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResultViewModel>(response);

            return RetornoOk();
        }

        public async Task<ResponseResultViewModel> AtualizarItemCarrinho(Guid produtoId, ItemProdutoViewModel produto)
        {
            var itemContent = ObterConteudo(produto);

            var response = await _httpClient.PutAsync($"/carrinho/{produto.ProdutoId}", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResultViewModel>(response);

            return RetornoOk();
        }

        public async Task<ResponseResultViewModel> RemoverItemCarrinho(Guid produtoId)
        {
            var response = await _httpClient.DeleteAsync($"/carrinho/{produtoId}");

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResultViewModel>(response);

            return RetornoOk();
        }
    }
}