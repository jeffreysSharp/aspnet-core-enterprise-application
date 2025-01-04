using JSE.WebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JSE.WebApp.MVC.Extensions
{
    public class PaginacaoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IPagedList modelopaginado)
        {
            return View(modelopaginado);
        }
    }
}
