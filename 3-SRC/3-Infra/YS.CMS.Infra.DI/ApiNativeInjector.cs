using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Common.Models.Result;
using YS.CMS.Common.Models.View;
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
            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

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
            services.AddTransient<IValidator<PostViewModel>, PostValidator>();
            services.AddTransient<IValidator<CategoryViewModel>, CategoryValidactor>();
            
            // >_ api version
            services.AddApiVersioning();

            // >_ Configs AutoMapper
            #region
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostViewModel, Post>()
                .ForMember(p => p.Id, pp => pp.Ignore())
                .ForMember(p => p.Categories, pp => pp.Ignore());
                
                cfg.CreateMap<CategoryViewModel, Category>()
                .ForMember(c => c.Id, cc => cc.Ignore())
                .ForMember(c => c.Posts, cc => cc.Ignore()); 

                cfg.CreateMap<Post, PostResultModel>()
                .ForMember(p => p.Categories, pp => pp.Ignore());

                cfg.CreateMap<CategoryResultModel, Category>()
               .ForMember(p => p.Posts, pp => pp.Ignore()); 
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            #endregion
        }
    }
}
