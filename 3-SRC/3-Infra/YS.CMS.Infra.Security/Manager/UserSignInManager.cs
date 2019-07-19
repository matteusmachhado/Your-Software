using YS.CMS.Domain.Base.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace YS.CMS.Infra.Security.Manager
{
    public class UserSignInManager : SignInManager<User>
    {
        public UserSignInManager(UserManager<User> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<User> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<User>> logger, IAuthenticationSchemeProvider schemes) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {

        }
    }
}
