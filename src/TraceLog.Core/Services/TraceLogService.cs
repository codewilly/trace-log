using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
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
                        Level = logLevel,
                        Message = message
                    });

                    _logger.Log(logLevel, message, args);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot write log: {message}", ex.Message);
            }
        }

        public void AddJsonLog<T>(LogLevel logLevel, T data, string? message = null) where T : class
        {
            try
            {
                string context = typeof(T).Name;

                lock (_traceLock)
                {
                    _trace.AddLog(new Log
                    {
                        Level = logLevel,
                        Message = message,
                        Context = context,
                        ContextData = data
                    });

                    JsonSerializerOptions options = new()
                    {
                        WriteIndented = true,
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };

                    string json = JsonSerializer.Serialize(data, options);

                    if (string.IsNullOrEmpty(message))
                        _logger.Log(logLevel, json);
                    else
                        _logger.Log(logLevel, "{message}:\n{json}", message, json);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot write log: {message}", ex.Message);
            }
        }
    }
}
