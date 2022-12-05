using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogger
{
    public abstract class LoggerBase
    {
        protected readonly object lockObj = new object();
        public abstract void Log(string message);
        public abstract void LogWarning(string message);
        public abstract void LogError(string message);
        public abstract void LogError(Exception exception);
        public abstract void LogError(string message, Exception exception);

        public abstract Task LogAsync(string message);
        public abstract Task LogWarningAsync(string message);
        public abstract Task LogErrorAsync(string message);
        public abstract Task LogErrorAsync(Exception exception);
        public abstract Task LogErrorAsync(string message, Exception exception);
    }
}
