namespace JSE.WebApp.MVC.Models
{
    public class ErrorViewModel
    {
        public int ErroCode { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
    }


    public class ResponseErrorMessages
    {
        public List<string> Mensagens { get; set; }
    }
}