using System;
using System.Collections.Generic;

namespace OpenGenericExample.Web.Logging
{
    public interface ILogWriter<T>
    {
        void LogInfo(string message);
        void LogWarning(string message, Exception ex = null);
        void LogError(string message, Exception ex);
        void LogEvent(string evt, IDictionary<string, object> metrics);
    }
}
