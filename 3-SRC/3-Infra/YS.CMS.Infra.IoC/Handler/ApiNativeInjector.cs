using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Infra.Data;

namespace YS.CMS.Infra.IoC.Handler
{
    public static class ApiNativeInjector
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CMSRepositoryContext>(options => 
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
