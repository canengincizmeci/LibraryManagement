using LibraryManagement.Core.CrossCuttingConcerns.Caching;
using LibraryManagement.Core.CrossCuttingConcerns.Caching.Microsoft;
using LibraryManagement.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace LibraryManagement.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
