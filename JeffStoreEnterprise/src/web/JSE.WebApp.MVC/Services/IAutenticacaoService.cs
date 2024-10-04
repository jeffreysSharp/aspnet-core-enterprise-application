using JSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services
{
    public interface IAutenticacaoService
    {
         Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLogin);

         Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistro);
    }
}