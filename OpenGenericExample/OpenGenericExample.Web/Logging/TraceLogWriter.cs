using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OpenGenericExample.Web.Logging
{
    public class TraceLogWriter<T> : ILogWriter<T>
    {
        private readonly string _messagePrefix;

        public TraceLogWriter()
        {
            _messagePrefix = $"[{typeof(T).Name}] ";
        }

        public void LogError(string message, Exception ex)
        {
            Trace.TraceError($"{_messagePrefix}{message} Error: {ex.Message}");
        }        

        public void LogInfo(string message)
        {
            Trace.TraceInformation($"{_messagePrefix}{message}");
        }

        public void LogWarning(string message, Exception ex = null)
        {
            var sb = new StringBuilder();
            sb.Append($"{_messagePrefix}{message}");

            if (ex != null)
            {
                sb.Append($" Error: {ex.Message}");
            }

            Trace.TraceError(sb.ToString());
        }
        public void LogEvent(string evt, IDictionary<string, object> metrics)
        {
            throw new NotImplementedException();
        }
    }
}
