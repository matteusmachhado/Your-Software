using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Infra.Security.Model;

namespace YS.CMS.Infra.Security.Handler
{
    public class UserHandler
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserHandler(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public UserHandler(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUser(RegisterModel model)
        {
            var user = new User { UserName = model.Login };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return result;
            }
            return result;
        }

        public async Task<SignInResult> LoginUser(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);
            if (result.Succeeded)
            {
                return result;
            }
            return result;
        }
    }
}
