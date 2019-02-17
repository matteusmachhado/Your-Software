using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YS.CMS.Domain.Entities;
using YS.CMS.Infra.Security;
using YS.CMS.Infra.Security.Model;

namespace YS.CMS.Services.ApiAuthProvider.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserHandler _userHandler;

        public UserController(UserManager<User> userManager)
        {
            _userHandler = new UserHandler(userManager);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHandler.CreateUser(model);

                if(result.Succeeded)
                {
                    return Ok(model);
                }
                return BadRequest();
            }
            return BadRequest();
        }
    }
}
