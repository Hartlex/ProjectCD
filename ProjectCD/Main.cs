using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.GlobalManagers;
using ProjectCD.GlobalManagers.Config;

namespace ProjectCD
{
    internal class Main
    {
        public void Initialize()
        {
            ConfigManager.Instance.LoadConfigurations();
            ServerManager.Instance.Initialize();
            ActionManager.Instance.Initialize();
        }
    }
}
