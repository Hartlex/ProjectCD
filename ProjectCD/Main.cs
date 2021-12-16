using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ServerManager.Instance.Initialize();
            ActionManager.Instance.Initialize();
            CommandActions.Instance.Init();
        }
    }
}
