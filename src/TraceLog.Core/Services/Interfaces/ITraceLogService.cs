﻿using Microsoft.Extensions.Logging;

namespace TraceLog.Core.Services.Interfaces
{
    public interface ITraceLogService
    {
        void AddLog(LogLevel logLevel, string message, params object[] args);

        void AddJsonLog<T>(LogLevel logLevel, T data, string? message = null) where T : class;
    }
}
