using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Infra.IoC.Handler;

namespace YS.CMS.Services.Api.Extensions
{
    public static class DependencyInjectionextension
    {
        public static void AddDependencyInjecion(this IServiceCollection service)
        {
            var injector = new ApiNativeInjector();
            injector.RegisterServices(service);
        }
    }
}
