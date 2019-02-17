using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Infra.IoC.Handler;

namespace YS.CMS.Services.ApiAuthProvider.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjecion(this IServiceCollection services)
        {
            var injector = new ApiAuthPrivaderNativeInjector();
            injector.RegisterServices(services);
        }
    }
}
