using System;

namespace Kits.DevlpKit.Tools.ConsoleLog
{
    public enum LogType
    {
        Log,
        Exception,
        Warning,
        Error,
        LogDebug
    }

    public interface ILogger
    {
        void Log(string txt,
            LogType type = LogType.Log,
            Exception e = null,
            System.Collections.Generic.Dictionary<string, string> data = null);

        void OnLoggerAdded();
    }
}