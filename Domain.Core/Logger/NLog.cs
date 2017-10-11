using NLog;
using System;

namespace FVG.FiscalAdapter.Domain.Core.Logger
{
    public class NLog : ILog
    {
        private readonly ILogger _log;

        public NLog(Type type)
        {
            _log = LogManager.GetLogger(type.FullName);
        }

        public void Debug(string format, params object[] args)
        {
            Log(LogLevel.Debug, format, args);
        }

        public void Info(string format, params object[] args)
        {
            Log(LogLevel.Info, format, args);
        }

        public void Warn(string format, params object[] args)
        {
            Log(LogLevel.Warn, format, args);
        }

        public void Error(string format, params object[] args)
        {
            Log(LogLevel.Error, format, args);
        }

        public void Error(Exception ex)
        {
            Log(LogLevel.Error, null, null, ex);
        }

        public void Error(Exception ex, string format, params object[] args)
        {
            Log(LogLevel.Error, format, args, ex);
        }

        public void Fatal(Exception ex, string format, params object[] args)
        {
            Log(LogLevel.Fatal, format, args, ex);
        }

        private void Log(LogLevel level, string format, object[] args)
        {
            _log.Log(typeof(NLog), new LogEventInfo(level, _log.Name, null, format, args));
        }

        private void Log(LogLevel level, string format, object[] args, Exception ex)
        {
            _log.Log(typeof(NLog), new LogEventInfo(level, _log.Name, null, format, args, ex));
        }
    }
}