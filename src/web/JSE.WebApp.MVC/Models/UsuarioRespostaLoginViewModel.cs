using JSE.Core.Communication;

namespace JSE.WebApp.MVC.Models
{
    public class UsuarioRespostaLoginViewModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioTokenViewModel UsuarioToken { get; set; }
        public ResponseResult ResponseResult { get; set; }
    }
}
