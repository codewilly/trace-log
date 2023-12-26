using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TraceLog.Core.Middlewares;
using TraceLog.Core.Services;
using TraceLog.Core.Services.Interfaces;

namespace TraceLog.Core.IoC
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddTraceLog(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ITraceLogService, TraceLogService>();
            services.AddTransient<TraceLogMiddleware>();

            return services;
        }

        public static void UseTraceLog(this WebApplication app)
        {
            ServiceProviderManager.Configure(app);

            app.UseMiddleware<TraceLogMiddleware>();
        }
    }
}
