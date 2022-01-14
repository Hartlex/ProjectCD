using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using ProjectCD.Servers.World.Actions;

namespace ProjectCD.Servers.World
{
    public class WorldActions : Singleton<WorldActions>
    {
        private ChatActions _chatActions = null!;
        private SyncActions _syncActions = null!;

        public void Initialize()
        {
            _chatActions = new ();
            _syncActions = new ();
        }

    }
}
