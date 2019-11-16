using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Infra.Security.Manager;
using YS.CMS.Infra.Security.Model;

namespace YS.CMS.Services.ApiAuthProvider.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/register")]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager _userManager;
        private readonly UserSignInManager _userSignInManager;

        public RegisterController(UserManager userManager, UserSignInManager userSignInManager)
        {
            _userManager = userManager;
            _userSignInManager = userSignInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email, PhoneNumber = model.PhoneNumber };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userSignInManager.SignInAsync(user, isPersistent: model.IsPersistent.HasValue);
                    return Ok(new { Ok = true, Msg = "Success" });
                }
                return BadRequest(new { Description = "Error in create user." }); // >_ Erro genérico por segurança.
            }
            return BadRequest();
        }
    }
}
