using CDShared.Generics;
using ProjectCD.Objects.NetObjects;

namespace ProjectCD.Commands
{
    public class CommandParser : Singleton<CommandParser>
    {
        public void ParseCommand(string str, User user)
        {
            if (!str.StartsWith("CMD:")) return;
            var cmd = new Command(str,user);
            cmd.Execute();
        }
    }
}
