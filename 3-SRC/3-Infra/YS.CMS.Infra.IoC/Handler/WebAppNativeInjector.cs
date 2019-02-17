using Microsoft.Extensions.DependencyInjection;
using System;
using YS.CMS.Infra.Data;
using YS.CMS.Infra.HttpClients;

namespace YS.CMS.Infra.IoC.Handler
{
    public class WebAppNativeInjector : NativeInjector
    {
        public override void RegisterServices(IServiceCollection services)
        {
            services.AddHttpClient<ApiAuthProviderClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5000/api/");
            });

            services.AddDbContext<CMSRepositoryContext>(optionsAction => AddDbContextOptionsBuilder());
        }
    }
}
