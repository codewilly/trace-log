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
            _service.AddLog(LogLevel.Information, message, args);
        }

        private static ITraceLogService _service => 
            ServiceProviderManager.GetScope().ServiceProvider.GetService<ITraceLogService>();
    }
}
