using JSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;

namespace JSE.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLoginViewModel)
        {
            var loginContent = ObterConteudo(usuarioLoginViewModel);

            var response = await _httpClient.PostAsync("http://localhost:5080/api/identidade/autenticar", loginContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLoginViewModel
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLoginViewModel>(response);
        }

        public async Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistroViewModel)
        {
            var registroContent = ObterConteudo(usuarioRegistroViewModel);

            var response = await _httpClient.PostAsync("http://localhost:5080/api/identidade/nova-conta", registroContent);

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