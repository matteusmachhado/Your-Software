using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Infra.CrossCutting.DI;

namespace YS.CMS.Services.ApiAuthProvider.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjecion(this IServiceCollection services, string connnectionString)
        {
            ApiAuthPrivaderNativeInjector.RegisterServices(services, connnectionString);
        }
    }
}
