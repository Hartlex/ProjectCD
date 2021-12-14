using System.Drawing;
using CDShared.Generics;

namespace CDShared.Logging
{
    public class Logger : Singleton<Logger>
    {
        private LogType _type = LogType.FULL;

        public void SetLogType(LogType type)
        {
            _type = type;
        }
        public void Log(string msg, LogType type = LogType.INFO)
        {
            if (type <= _type)
            {
                Console.ForegroundColor = GetColor(type);
                Console.WriteLine(msg);
            }
                
        }

        public void Log(object obj,LogType type = LogType.INFO)
        {
            Log(obj.ToString() ?? string.Empty, type);
        }
        public void Log(Exception e)
        {
            Log(e.ToString(),LogType.ERROR);
        }

        private ConsoleColor GetColor(LogType type)
        {
            switch (type)
            {
                case LogType.SYSTEM_MESSAGE:
                    return ConsoleColor.Magenta;
                case LogType.ERROR:
                    return ConsoleColor.Red;
                case LogType.SUCCESS:
                    return ConsoleColor.Green;
                case LogType.WARNING:
                    return ConsoleColor.Yellow;
                case LogType.INFO:
                    return ConsoleColor.White;
                case LogType.FULL:
                    return ConsoleColor.DarkGray;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public void LogOnLine(string msg, LogType type = LogType.INFO)
        {
            if (type <= _type)
            {
                Console.ForegroundColor = GetColor(type);
                Console.Write("\r " +msg);
            }
        }
    }
    public enum LogType
    { 
        SYSTEM_MESSAGE=1,
        ERROR = 2,
        SUCCESS = 10,
        WARNING = 100,
        INFO =200,
        FULL=1000
    }

}
