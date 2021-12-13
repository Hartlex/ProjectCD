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
        private ConnectionActions _connectionActions = null!;
        private CharInfoActions _charInfoActions = null!;
        private SyncActions _syncActions = null!;
        public void Initialize()
        {
            _connectionActions = new();
            _charInfoActions = new();
            _syncActions = new();
        }
    }
}
