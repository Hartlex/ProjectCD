using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using ProjectCD.Servers.Auth;
using ProjectCD.Servers.Game;

namespace ProjectCD.GlobalManagers
{
    public class ActionManager : Singleton<ActionManager>
    {
        public void Initialize()
        {
            AuthActions.Instance.Initialize();
            GameActions.Instance.Initialize();
        }
    }
}
