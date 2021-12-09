using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server.Config;
using CDShared.Logging;
using NetworkCommsDotNet.Connections;

namespace ProjectCD.Servers.Channel
{
    internal sealed class ChannelServer : CDServer
    {
        public ChannelServer(ServerConfig config) : base(config)
        {

        }

        protected override void OnConnect(Connection connection)
        {
            
        }
    }
}
