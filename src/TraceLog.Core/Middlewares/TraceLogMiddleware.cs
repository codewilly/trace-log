using Microsoft.AspNetCore.Http;
using TraceLog.Core.Services.Interfaces;

namespace TraceLog.Core.Middlewares
{
    internal class TraceLogMiddleware : IMiddleware
    {
        private readonly ITraceLogService _service;

        public TraceLogMiddleware(ITraceLogService service)
        {
            _service = service;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
        }
    }
}
