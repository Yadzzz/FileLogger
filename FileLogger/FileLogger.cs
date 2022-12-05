using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogger
{
    public class FileLogger : LoggerBase
    {
        protected readonly object lockObj = new object();
        private LoggerConfiguration _loggerConfiguration;

        public FileLogger(LoggerConfiguration loggerConfiguration)
        {
            this._loggerConfiguration = loggerConfiguration;
        }

        public LoggerConfiguration LoggerConfiguration
        {
            get
            {
                return _loggerConfiguration;
            }
        }

        public override void Log(string message)
        {
            if (!this._loggerConfiguration.PathExists())
            {
                Console.WriteLine("Could not log, path is not accessible.");

                return;
            }

            lock (lockObj)
            {
                using (var writer = this._loggerConfiguration.GetStreamWriter())
                {
                    writer.WriteLine("[" + DateTime.Now + "] [INF] " + message);
                }
            }
        }

        public override async Task LogAsync(string message)
        {
            if (!this._loggerConfiguration.PathExists())
            {
                Console.WriteLine("Could not log, path is not accessible.");

                return;
            }

            using (var writer = this._loggerConfiguration.GetStreamWriter())
            {
                await writer.WriteLineAsync("[" + DateTime.Now + "] [INF] " + message);
            }
        }

        public override void LogError(string message)
        {
            if (!this._loggerConfiguration.PathExists())
            {
                Console.WriteLine("Could not log, path is not accessible.");

                return;
            }

            lock (lockObj)
            {
                using (var writer = this._loggerConfiguration.GetStreamWriter())
                {
                    writer.WriteLine("[" + DateTime.Now + "] [ERR] " + message);
                }
            }
        }

        public override async Task LogErrorAsync(string message)
        {
            if (!this._loggerConfiguration.PathExists())
            {
                Console.WriteLine("Could not log, path is not accessible.");

                return;
            }

            using (var writer = this._loggerConfiguration.GetStreamWriter())
            {
                await writer.WriteLineAsync("[" + DateTime.Now + "] [ERR] " + message);
            }
        }

        public override void LogError(string message, Exception exception)
        {
            if (!this._loggerConfiguration.PathExists())
            {
                Console.WriteLine("Could not log, path is not accessible.");

                return;
            }

            lock (lockObj)
            {
                using (var writer = this._loggerConfiguration.GetStreamWriter())
                {
                    writer.WriteLine("[" + DateTime.Now + "] [ERR] " + message);
                    writer.WriteLine("[" + DateTime.Now + "] [ERR] " + exception.ToString());
                }
            }
        }

        public override async Task LogErrorAsync(string message, Exception exception)
        {
            if (!this._loggerConfiguration.PathExists())
            {
                Console.WriteLine("Could not log, path is not accessible.");

                return;
            }

            using (var writer = this._loggerConfiguration.GetStreamWriter())
            {
                await writer.WriteLineAsync("[" + DateTime.Now + "] [ERR] " + message);
                await writer.WriteLineAsync("[" + DateTime.Now + "] [ERR] " + exception.ToString());
            }
        }

        public override void LogError(Exception exception)
        {
            if (!this._loggerConfiguration.PathExists())
            {
                Console.WriteLine("Could not log, path is not accessible.");

                return;
            }

            lock (lockObj)
            {
                using (var writer = this._loggerConfiguration.GetStreamWriter())
                {
                    writer.WriteLine("[" + DateTime.Now + "] [ERR] " + exception.ToString());
                }
            }
        }

        public override async Task LogErrorAsync(Exception exception)
        {
            if (!this._loggerConfiguration.PathExists())
            {
                Console.WriteLine("Could not log, path is not accessible.");

                return;
            }

            using (var writer = this._loggerConfiguration.GetStreamWriter())
            {
                await writer.WriteLineAsync("[" + DateTime.Now + "] [ERR] " + exception.ToString());
            }
        }

        public override void LogWarning(string message)
        {
            if (!this._loggerConfiguration.PathExists())
            {
                Console.WriteLine("Could not log, path is not accessible.");

                return;
            }

            lock (lockObj)
            {
                using (var writer = this._loggerConfiguration.GetStreamWriter())
                {
                    writer.WriteLine("[" + DateTime.Now + "] [WRN] " + message);
                }
            }
        }

        public override async Task LogWarningAsync(string message)
        {
            if (!this._loggerConfiguration.PathExists())
            {
                Console.WriteLine("Could not log, path is not accessible.");

                return;
            }

            using (var writer = this._loggerConfiguration.GetStreamWriter())
            {
                await writer.WriteLineAsync("[" + DateTime.Now + "] [WRN] " + message);
            }
        }
    }
}
