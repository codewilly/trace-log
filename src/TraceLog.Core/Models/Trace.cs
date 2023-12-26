using System.Collections.ObjectModel;

namespace TraceLog.Core.Models
{
    public class Trace
    {
        public Trace(string traceId)
        {
            Id = traceId;
            Logs = new Collection<Log>();
        }

        public string Id { get; set; }

        public ICollection<Log> Logs { get; set; }

        public void AddLog(Log log)
        {
            Logs.Add(log);
        }
    }
}
