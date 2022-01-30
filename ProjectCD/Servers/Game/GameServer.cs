using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server.Config;
using CDShared.Logging;
using ProjectCD.NetworkBase.Connections;
using ProjectCD.Objects.Game.World;
using ProjectCD.Servers.World;
using SunStructs.Definitions;

namespace ProjectCD.Servers.Game
{
    public class GameServer : CDServer
    {
        private readonly WorldServer _worldServer;
        private readonly FieldManager _fieldManager;
        private readonly System.Timers.Timer _updateTimer;
        public GameServer(ServerConfig config, WorldServer worldServer) : base(config)
        {
            _worldServer = worldServer;
            _fieldManager = new (this);
            _updateTimer = new System.Timers.Timer(Const.SERVER_UPDATE_TIME);
            _updateTimer.Elapsed += (sender, args) => Update();
            _updateTimer.AutoReset = true;
            _updateTimer.Start();
        }

        private void Update()
        {
            var tick = DateTime.Now.Ticks;
            _fieldManager.Update(tick);
            var endTick = DateTime.Now.Ticks;
            var elapsed =(float) ((endTick - tick)/TimeSpan.TicksPerMillisecond);
            var perf = elapsed / Const.SERVER_UPDATE_TIME;
            if (perf > 0.5 )
                Logger.Instance.Log($"GameServer performance is at {elapsed*100}");
        }

        protected override void OnConnect(Connection connection)
        {
            Logger.Instance.Log("Gameserver Connection");
        }

        public GameField GetField(uint mapCode)
        {
            return _fieldManager.GetField(mapCode);
        }

        public WorldServer GetWorldServer()
        {
            return _worldServer;
        }
        
    }
}
