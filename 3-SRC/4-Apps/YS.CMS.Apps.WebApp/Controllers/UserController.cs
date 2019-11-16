using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YS.CMS.Infra.CrossCutting.Clients.Internal.Http.Controllers;
using YS.CMS.Infra.Security.Model;

namespace YS.CMS.Apps.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly AuthCliente _api;

        public UserController(AuthCliente api)
        {
            _api = api;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _api.PostLoginAsync(model);
                if (result.Succeeded)
                {
                    /*
                        >_ Criando direitos/reinvindicações/claims
                    */
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.UserName),
                        new Claim("Token", result.Token) // >_ Guardando o Token
                    };

                    /*
                        >_ Aguardando direitos na Identity principal.
                    */
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProp = new AuthenticationProperties
                    {
                        IssuedUtc = DateTime.UtcNow,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(25), // >_ Expirações do cookie sempre menor que a do token.
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(claimsIdentity), 
                        authProp);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(String.Empty, "Erro na autenticação");
                return View(model);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                await _api.PostRegisterAsync(model);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}