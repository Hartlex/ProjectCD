using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server.Config;
using ProjectCD.NetworkBase.Connections;

namespace ProjectCD.Servers.World
{
    internal class WorldServer : CDServer
    {
        public WorldServer(ServerConfig config) : base(config)
        {
        }

        protected override void OnConnect(Connection connection)
        {
            throw new NotImplementedException();
        }
    }
}
