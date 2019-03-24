﻿using Microsoft.Extensions.DependencyInjection;
using YS.CMS.Infra.CrossCutting.DI;

namespace YS.CMS.Apps.WebApp.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjecion(this IServiceCollection services)
        {
            WebAppNativeInjector.RegisterServices(services);
        }
    }
}
