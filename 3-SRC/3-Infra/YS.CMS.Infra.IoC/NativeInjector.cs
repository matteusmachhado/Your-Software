using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace YS.CMS.Infra.IoC
{
    public abstract class NativeInjector
    {
        private static string connnectionString = "Server=localhost\\SQLEXPRESS;Database=CMS;User ID=matteusmachhado;Password=123456;";

        protected Action<DbContextOptionsBuilder> AddDbContextOptionsBuilder = (options) => options.UseSqlServer(connnectionString);

        public abstract void RegisterServices(IServiceCollection services);
    }
}
