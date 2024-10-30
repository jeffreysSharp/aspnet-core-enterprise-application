using JSE.WebApp.MVC.Models;

namespace JSE.WebApp.MVC.Services
{
    public interface IAutenticacaoService
    {
         Task<UsuarioRespostaLoginViewModel> Login(UsuarioLoginViewModel usuarioLogin);

         Task<UsuarioRespostaLoginViewModel> Registro(UsuarioRegistroViewModel usuarioRegistro);
    }
}