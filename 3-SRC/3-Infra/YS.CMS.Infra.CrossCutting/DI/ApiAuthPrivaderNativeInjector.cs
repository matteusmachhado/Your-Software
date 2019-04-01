using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Infra.Security;

namespace YS.CMS.Infra.CrossCutting.DI
{
    public static class ApiAuthPrivaderNativeInjector
    {
        public static void RegisterServices(IServiceCollection services, string connnectionString)
        {
            services.AddDbContext<CMSAuthContext>(options =>
            {
                options.UseSqlServer(connnectionString);
            });

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<CMSAuthContext>();
        }
    }
}
