namespace JSE.WebApp.MVC.Models
{
    public class UsuarioLoginRespostaViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioTokenViewModel UsuarioToken { get; set; }
    }
}
