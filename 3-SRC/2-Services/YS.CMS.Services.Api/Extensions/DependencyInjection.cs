using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Infra.DI;

namespace YS.CMS.Services.Api.Extensions
{
    public static class DependencyInjectionextension
    {
        public static void AddDependencyInjecion(this IServiceCollection service, string connnectionString)
        {
            ApiNativeInjector.RegisterServices(service, connnectionString);
        }
    }
}
