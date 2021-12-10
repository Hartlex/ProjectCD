using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server.Config;
using CDShared.Logging;
using NetworkCommsDotNet.Connections;

namespace ProjectCD.Servers.Game
{
    internal class GameServer : CDServer
    {
        public GameServer(ServerConfig config) : base(config)
        {
        }

        public override void OnConnect(Connection connection)
        {
            
        }
        
    }
}
