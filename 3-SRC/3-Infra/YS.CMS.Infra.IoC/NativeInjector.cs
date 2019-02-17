using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace YS.CMS.Infra.IoC
{
    public abstract class NativeInjector
    {
        private readonly string connnectionString = "Server=localhost\\SQLEXPRESS;Database=CMS;User ID=matteusmachhado;Password=123456;";
        
        protected DbContextOptionsBuilder AddDbContextOptionsBuilder()
        {
            return new DbContextOptionsBuilder().UseSqlServer(connnectionString); 
        }

        public abstract void RegisterServices(IServiceCollection services);
    }
}
