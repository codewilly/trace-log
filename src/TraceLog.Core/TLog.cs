using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TraceLog.Core.IoC;
using TraceLog.Core.Services.Interfaces;

namespace TraceLog.Core
{
    public static class TLog
    {
        public static void Information(string message, params object[] args)
        {
            _service.AddLog(LogLevel.Information, "default", message, args);
        }   

        public static void Json<T>(T data, string? message = null) where T : class
        {
            _service.AddJsonLog(LogLevel.Information, data, message);
        }

        private static ITraceLogService _service => 
            ServiceProviderManager.GetScope().ServiceProvider.GetService<ITraceLogService>();
    }
}
