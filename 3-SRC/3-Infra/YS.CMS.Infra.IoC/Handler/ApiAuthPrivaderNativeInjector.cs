using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Domain.Entities;
using YS.CMS.Infra.Data;

namespace YS.CMS.Infra.IoC.Handler
{
    public class ApiAuthPrivaderNativeInjector : NativeInjector
    {
        public override void RegisterServices(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<CMSContext>();

            services.AddDbContext<CMSContext>(optionsAction => AddDbContextOptionsBuilder());
        }
    }
}
