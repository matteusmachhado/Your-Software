using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Infra.Security.Handler;
using YS.CMS.Infra.Security.Model;

namespace YS.CMS.Services.ApiAuthProvider.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/login")]
    public class LoginController : ControllerBase
    {
        private readonly UserHandler _userHandler;
        private readonly IConfiguration _configuration;

        public LoginController(SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userHandler = new UserHandler(signInManager);
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHandler.LoginUser(model);
                if (result.Succeeded)
                {
                    var token = new TokenJWTHandler().GeneratorToken(model, 
                            securityKey:    _configuration["AppSettings:securityKey"], 
                            issuer:         _configuration["AppSettings:issuer"], 
                            audience:       _configuration["AppSettings:audience"], 
                            expiresMinutes: double.Parse(_configuration["AppSettings:expiresMinutes"]));
                    return Ok(token);
                }
                return Unauthorized();
            }
            return BadRequest();
        }
    }
}