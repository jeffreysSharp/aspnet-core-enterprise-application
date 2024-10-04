using JSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System.Text.Json;
using System.Text;

namespace JSE.WebApp.MVC.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLoginViewModel)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(usuarioLoginViewModel),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5080/api/identidade/autenticar", loginContent);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<UsuarioRespostaLoginViewModel>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistroViewModel)
        {
            var registroContent = new StringContent(
                JsonSerializer.Serialize(usuarioRegistroViewModel),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5080/api/identidade/nova-conta", registroContent);

            return JsonSerializer.Deserialize<UsuarioRespostaLoginViewModel>(await response.Content.ReadAsStringAsync());
        }
    }
}