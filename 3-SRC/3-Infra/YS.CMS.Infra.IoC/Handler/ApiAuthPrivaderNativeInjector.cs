using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Domain.Entities;
using YS.CMS.Infra.Security;
using Microsoft.EntityFrameworkCore;

namespace YS.CMS.Infra.IoC.Handler
{
    public class ApiAuthPrivaderNativeInjector : NativeInjector
    {
        public override void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<CMSAuthContext>(options => {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CMS;User ID=matteusmachhado;Password=123456;");
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
