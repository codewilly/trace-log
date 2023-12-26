using Microsoft.Extensions.Logging;

namespace TraceLog.Core.Models
{
    public class Log
    {
        public Log()
        {
            Id = Guid.NewGuid();
            At = DateTime.Now;
        }
        public Guid Id { get; set; }

        public DateTime At { get; set; }

        public LogLevel Level { get; set; }

        public string? Message { get; set; }

        public string Context { get; set; } = "default";

        public object? ContextData { get; set; }
    }
}
