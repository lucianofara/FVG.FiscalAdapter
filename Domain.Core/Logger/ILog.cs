using System;

namespace FVG.FiscalAdapter.Domain.Core.Logger
{
    public interface ILog
    {
        void Debug(string format, params object[] args);

        void Info(string format, params object[] args);

        void Warn(string format, params object[] args);

        void Error(string format, params object[] args);

        void Error(Exception ex);

        void Error(Exception ex, string format, params object[] args);

        void Fatal(Exception ex, string format, params object[] args);
    }
}