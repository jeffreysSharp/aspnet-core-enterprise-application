namespace JSE.WebApp.MVC.Models
{
    public class ResponseResultViewModel
    {
        public ResponseResultViewModel()
        {
            Errors = new ResponseErrorMessagesViewModel();
        }

        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessagesViewModel Errors { get; set; }
    }
}
