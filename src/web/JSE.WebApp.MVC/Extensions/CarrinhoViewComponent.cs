using Microsoft.AspNetCore.Mvc;
using JSE.WebApp.MVC.Models;
using JSE.WebApp.MVC.Services;

namespace JSE.WebApp.MVC.Extensions
{
    public class CarrinhoViewComponent : ViewComponent
    {
        private readonly IComprasBffService _comprasBffService;

        public CarrinhoViewComponent(IComprasBffService comprasBffService)
        {
            _comprasBffService = comprasBffService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _comprasBffService.ObterQuantidadeCarrinho() );
        }
    }
}