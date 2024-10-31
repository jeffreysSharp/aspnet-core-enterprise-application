﻿using JSE.WebApp.MVC.Extensions;
using JSE.WebApp.MVC.Models;
using Microsoft.Extensions.Options;

namespace JSE.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {   
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var response = await _httpClient.PostAsync("https://localhost:44396/api/identidade/autenticar", loginContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLoginViewModel
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLoginViewModel>(response);
        }

        public async Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);

            var response = await _httpClient.PostAsync("https://localhost:44396/api/identidade/nova-conta", registroContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLoginViewModel
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLoginViewModel>(response);
        }
    }
}