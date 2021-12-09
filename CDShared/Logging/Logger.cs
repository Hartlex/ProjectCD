using CDShared.Generics;

namespace CDShared.Logging
{
    public class Logger : Singleton<Logger>
    {
        public void Log(string msg, LogType type = LogType.INFO)
        {
            Console.WriteLine(msg);
        }

        public void Log(object obj,LogType type = LogType.INFO)
        {
            Log(obj.ToString(), type);
        }
        public void Log(Exception e)
        {
            Log(e.ToString(),LogType.ERROR);
        }
    }
    public enum LogType
    { 
        SYSTEM_MESSAGE=1,
        ERROR = 2,
        SUCCESS = 10,
        WARNING = 101,
        INFO =201,
        NETWORK_INFO=1000
    }
    public enum LogLevel
    {        
        NONE=0,
        MINIMAL=3,
        STANDARD=11,
        RELEASE=200,
        DEBUG=300,
        FULL=Int32.MaxValue, 

    }
}
