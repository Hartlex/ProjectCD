using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.Servers.Auth;
using ProjectCD.Servers.Game;
using ProjectCD.Servers.World;

namespace ProjectCD.GlobalManagers
{
    public class ActionManager : Singleton<ActionManager>
    {
        public void Initialize()
        {
            Logger.Instance.Log("Loading PacketActions...",LogType.SYSTEM_MESSAGE);
            Logger.Instance.LogLine(LogType.SYSTEM_MESSAGE);
            AuthActions.Instance.Initialize();
            GameActions.Instance.Initialize();
            WorldActions.Instance.Initialize();
            Logger.Instance.LogLine(LogType.SYSTEM_MESSAGE);
        }
    }
}
