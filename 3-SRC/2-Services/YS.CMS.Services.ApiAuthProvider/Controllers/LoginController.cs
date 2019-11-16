using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YS.CMS.Infra.Security.Handler;
using YS.CMS.Infra.Security.Manager;
using YS.CMS.Infra.Security.Model;

namespace YS.CMS.Services.ApiAuthProvider.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/login")]
    public class LoginController : ControllerBase
    {
        private readonly UserSignInManager _userSignInManager;
        private readonly IConfiguration _configuration;

        public LoginController(UserSignInManager userSignInManager, IConfiguration configuration)
        {
            _userSignInManager = userSignInManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userSignInManager.PasswordSignInAsync(
                    model.UserName, 
                    model.Password, 
                    isPersistent: model.IsPersistent, 
                    lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    var token = new TokenJWTHandler().GeneratorToken(model, 
                            securityKey:    _configuration["AppSettings:securityKey"], 
                            issuer:         _configuration["AppSettings:issuer"], 
                            audience:       _configuration["AppSettings:audience"], 
                            expiresMinutes: double.Parse(_configuration["AppSettings:expiresMinutes"]));
                    return Ok(new { _token = token, ok = true});
                }
                return BadRequest(new { Login = "Não autorizado." });
            }
            return BadRequest(new { Login = "Não autorizado." });
        }
    }
}