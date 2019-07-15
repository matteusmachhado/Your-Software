using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Common.Models.Results;
using YS.CMS.Common.Models.Views;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Domain.Base.Interfaces;
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

            // >_ Repositorys
            services.AddTransient<IPost, PostRepositorio>();
            services.AddTransient<ICategory, CategoryRepository>();

            services.AddMvc(setup =>
            {   // >_ set configs validators

            }).AddFluentValidation();

            // >_ add validators
            services.AddTransient<IValidator<Post>, PostValidator>();
            services.AddTransient<IValidator<Category>, CategoryValidactor>();
            
            // >_ api version
            services.AddApiVersioning();

            // >_ AutoMapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {                                                              // >_ Ignore recursive (recursive) 
                cfg.CreateMap<Post, PostResultModel>().ForMember(p => p.Categories, pr => pr.Ignore());
                cfg.CreateMap<Category, CategoryResultModel>().ForMember(p => p.Posts, pr => pr.Ignore());
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
