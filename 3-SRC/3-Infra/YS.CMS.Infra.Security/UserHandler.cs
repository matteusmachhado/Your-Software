using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using YS.CMS.Domain.Entities;
using YS.CMS.Infra.Security.Model;

namespace YS.CMS.Infra.Security
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

        public async Task<UserManagerResultModel> CreateUser(User model)
        {
            var user = new User { UserName = model.UserName };
            var result = await _userManager.CreateAsync(user, model.PasswordHash);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return new UserManagerResultModel { Succeeded = true };
            }
            return new UserManagerResultModel { Succeeded = false };
        }
    }
}
