using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public LoginController(SignInManager<User> signInManager, ILogger<LoginController> logger)
        {
            _userHandler = new UserHandler(signInManager);
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            _logger.LogInformation("Login:{1};Senha:********",  model.Login);
            if (ModelState.IsValid)
            {
                var result = await _userHandler.LoginUser(model);
                if (result.Succeeded)
                {
                    var token = new TokenJWTHandler().GeneratorToken(model);
                    return Ok(token);
                }
                return Unauthorized();
            }
            return BadRequest();
        }
    }
}