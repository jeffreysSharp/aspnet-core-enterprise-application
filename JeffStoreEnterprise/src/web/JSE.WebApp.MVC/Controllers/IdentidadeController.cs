using JSE.WebApp.MVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Services;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using NSE.WebApp.MVC.Controllers;

namespace JSE.WebApp.MVC.Controllers
{
    public class IdentidadeController : MainController
    {

        private readonly IAutenticacaoService _autenticacaoService;

        public IdentidadeController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

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

            var resposta = await _autenticacaoService.Registro(usuarioRegistroViewModel);

            if (ResponsePossuiErros(resposta.ResponseResult)) return View(usuarioRegistroViewModel);

            await RealizarLogin(resposta);

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

            var resposta = await _autenticacaoService.Login(usuarioLoginViewModel);

            if (ResponsePossuiErros(resposta.ResponseResult)) return View(usuarioLoginViewModel);

            await RealizarLogin(resposta);            

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task RealizarLogin(UsuarioRespostaLoginViewModel usuarioRespostaLoginViewModel)
        {
            var token = ObterTokenFormatado(usuarioRespostaLoginViewModel.AccessToken);

            var claims = new List<Claim>();
            claims.Add(new Claim("JWT", usuarioRespostaLoginViewModel.AccessToken));
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        private static JwtSecurityToken ObterTokenFormatado(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }
    }
}
