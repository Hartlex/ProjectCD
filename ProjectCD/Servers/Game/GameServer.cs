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

namespace ProjectCD.Servers.Game
{
    public class GameServer : CDServer
    {
        private readonly WorldServer _worldServer;
        private readonly FieldManager _fieldManager;
        public GameServer(ServerConfig config, WorldServer worldServer) : base(config)
        {
            _worldServer = worldServer;
            _fieldManager = new (this);
        }

        protected override void OnConnect(Connection connection)
        {
            
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
