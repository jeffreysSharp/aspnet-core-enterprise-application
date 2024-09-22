using JSE.WebApp.MVC.Models;

namespace JSE.WebApp.MVC.Models
{
    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessagesViewModel Errors { get; set; }
    }
}
