namespace JSE.WebApp.MVC.Models
{
    public class ResponseErrorMessagesViewModel
    {
        public ResponseErrorMessagesViewModel()
        {
            Mensagens = new List<string>();
        }
        public List<string> Mensagens { get; set; }
    }
}
