using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using ProjectCD.Servers.Game.Actions;

namespace ProjectCD.Servers.Game
{
    internal class GameActions : Singleton<GameActions>
    {


        public void Initialize()
        {
            ConnectionActions.Initialize();
            CharInfoActions.Initialize();
            SyncActions.Initialize();
            ItemActions.Initialize();
            ZoneActions.Initialize();
            BattleActions.Initialize();
            SkillActions.Initialize();
        }
    }
}
