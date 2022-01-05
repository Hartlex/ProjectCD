using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using ProjectCD.Commands;
using ProjectCD.GlobalManagers;
using ProjectCD.GlobalManagers.Config;
using ProjectCD.GlobalManagers.DB;

namespace ProjectCD
{
    internal class Main
    {
        public void Initialize()
        {
            ConfigManager.Instance.LoadConfigurations();
            Database.Instance.Initialize();
            RuntimeDataBase.Instance.Initialize();
            ObjectFactory.Instance.Initialize();
            ActionManager.Instance.Initialize();
            ServerManager.Instance.Initialize();

            CommandActions.Instance.Init();
        }
    }
}
