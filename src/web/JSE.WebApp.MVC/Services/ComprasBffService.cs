﻿using JSE.Core.Communication;
using JSE.WebApp.MVC.Extensions;
using JSE.WebApp.MVC.Models;
using Microsoft.Extensions.Options;

namespace JSE.WebApp.MVC.Services
{
    public class ComprasBffService : Service, IComprasBffService
    {
        private readonly HttpClient _httpClient;

        public ComprasBffService(HttpClient httpClient,
            IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            httpClient.BaseAddress = new Uri(settings.Value.ComprasBffUrl);
            
        }

        #region Carrinho

        public async Task<CarrinhoViewModel> ObterCarrinho()
        {
            var response = await _httpClient.GetAsync("/compras/carrinho/");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<CarrinhoViewModel>(response);
        }

        public async Task<int> ObterQuantidadeCarrinho()
        {
            var response = await _httpClient.GetAsync("/compras/carrinho-quantidade/");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<int>(response);
        }

        public async Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoViewModel carrinho)
        {
            var itemContent = ObterConteudo(carrinho);

            var response = await _httpClient.PostAsync("/compras/carrinho/items/", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel item)
        {
            var itemContent = ObterConteudo(item);

            var response = await _httpClient.PutAsync($"/compras/carrinho/items/{produtoId}", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> RemoverItemCarrinho(Guid produtoId)
        {
            var response = await _httpClient.DeleteAsync($"/compras/carrinho/items/{produtoId}");

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> AplicarVoucherCarrinho(string voucher)
        {
            var itemContent = ObterConteudo(voucher);

            var response = await _httpClient.PostAsync("/compras/carrinho/aplicar-voucher/", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return RetornoOk();
        }

        #endregion
    }
}