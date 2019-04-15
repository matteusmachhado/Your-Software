using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Domain.Base.interfaces;
using YS.CMS.Infra.Data;
using YS.CMS.Infra.Data.Repository;
using YS.CMS.Infra.Security.Validators;

namespace YS.CMS.Infra.DI
{
    public static class ApiNativeInjector
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CMSRepositoryContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<IPost, PostRepositorio>();
            services.AddTransient<IRepositorioBase<Category>, RepositorioBase<Category>>();
            services.AddMvc(setup =>
            {   // >_ set configs validators

            }).AddFluentValidation();

            // >_ add validators
            services.AddTransient<IValidator<Post>, PostValidator>();
        }
    }
}
