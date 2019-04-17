using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Infra.CrossCutting.Clients.Internal.Http.Controllers;
using System;
using Microsoft.AspNetCore.Http;

namespace YS.CMS.Infra.DI
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

            services.AddHttpClient<AuthCliente>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/v1.0/");
            });

            services.AddHttpClient<PostClient>(client => 
            {
                client.BaseAddress = new Uri("http://localhost:6000/api/v1.0/");
            });

            // >_ Acessor - _token
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
