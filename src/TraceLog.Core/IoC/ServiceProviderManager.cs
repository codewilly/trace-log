using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TraceLog.Core.IoC
{
    internal class ServiceProviderManager
    {
        internal static IServiceProvider _serviceProvider;

        public static void Configure(IApplicationBuilder app)
        {
            _serviceProvider = app.ApplicationServices;
        }

        public static IServiceScope GetScope()
        {
            return _serviceProvider!.GetRequiredService<IServiceScopeFactory>().CreateScope();
        }
    }
}
