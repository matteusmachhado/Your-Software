using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Infra.Data;

namespace YS.CMS.Infra.IoC.Handler
{
    public class ApiNativeInjector : NativeInjector
    {
        public override void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<CMSRepositoryContext>(AddDbContextOptionsBuilder);
        }
    }
}
