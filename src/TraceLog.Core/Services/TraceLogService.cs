using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TraceLog.Core.Models;
using TraceLog.Core.Services.Interfaces;

namespace TraceLog.Core.Services
{
    public class TraceLogService : ITraceLogService
    {
        private readonly Trace _trace;
        private readonly object _traceLock = new();
        private readonly ILogger<Log> _logger;

        public TraceLogService(IHttpContextAccessor context,
                               ILogger<Log> logger)
        {
            _trace = new(context?.HttpContext?.TraceIdentifier ?? "");
            _logger = logger;
        }

        public void AddLog(LogLevel logLevel, string message, params object[] args)
        {
            try
            {
                lock (_traceLock)
                {
                    _trace.AddLog(new Log
                    {
                        Id = Guid.NewGuid(),
                        Level = logLevel,
                        Message = message
                    });

                    throw new Exception("teste");

                    _logger.Log(logLevel, message, args);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot write log: {message}", ex.Message);
           }
        }
    }
}
