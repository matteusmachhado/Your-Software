using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System;
using YS.CMS.Infra.Clients.HTTP;
using YS.CMS.Infra.Data;

namespace YS.CMS.Infra.IoC.Handler
{
    public class WebAppNativeInjector : NativeInjector
    {
        public override void RegisterServices(IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/User/Login";
                });

            services.AddHttpClient<ApiAuthProviderClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/");
            });

            services.AddDbContext<CMSRepositoryContext>(AddDbContextOptionsBuilder);
        }
    }
}
