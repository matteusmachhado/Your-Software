using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using YS.CMS.Domain.Entities;
using YS.CMS.Infra.Data;
using YS.CMS.Infra.HttpClients;

namespace YS.CMS.Infra.IoC.Handler
{
    public class ApiAuthPrivaderNativeInjector : NativeInjector
    {
        public override void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpClient<ApiAuthProviderClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/");
            });

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
