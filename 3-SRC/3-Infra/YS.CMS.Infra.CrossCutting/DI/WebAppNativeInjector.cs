using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Infra.CrossCutting.Clients.Core.Http.Controllers;
using System;

namespace YS.CMS.Infra.CrossCutting.DI
{
    public static class WebAppNativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/User/Login";
                });

            services.AddHttpClient<AuthProviderClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/");
            });
        }
    }
}
