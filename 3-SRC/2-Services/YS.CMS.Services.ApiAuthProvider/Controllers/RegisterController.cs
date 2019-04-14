using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Infra.Security.Handler;
using YS.CMS.Infra.Security.Model;

namespace YS.CMS.Services.ApiAuthProvider.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly UserHandler _userHandler;

        public RegisterController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userHandler = new UserHandler(userManager, signInManager);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHandler.RegisterUser(model);

                if(result.Succeeded)
                {
                    return Ok(result);
                }
                // >_ sem retorno por segurança.
            }
            return BadRequest();
        }
    }
}
