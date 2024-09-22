using JSE.WebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace JSE.WebApp.MVC.Controllers
{
    public class IdentidadeController : Controller
    {
        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistroViewModel usuarioRegistroViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioRegistroViewModel);

            if (false) return View(usuarioRegistroViewModel);

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLoginViewModel usuarioLoginViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioLoginViewModel);

            if (false) return View(usuarioLoginViewModel);

            return RedirectToAction("Index", "Home");


        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
