using Microsoft.Extensions.Logging;

namespace TraceLog.Core.Models
{
    public class Log
    {
        public Guid Id { get; set; }

        public LogLevel Level { get; set; }

        public string Message { get; set; }
    }
}
