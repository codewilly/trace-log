using Microsoft.AspNetCore.Http;
using TraceLog.Core.Models.Contexts;
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

            context.Request.EnableBuffering();


            TLog.Json(new RequestLogContext
            {
                Method = "GET",
                Route = "teste"
            });

            TLog.Json(new ResponseLogContext
            {
                StatusCode = 200
            });

            await next(context);
        }
    }
}
