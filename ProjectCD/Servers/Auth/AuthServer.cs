using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server.Config;
using NetworkCommsDotNet.Connections;

namespace ProjectCD.Servers.Auth
{
    internal sealed class AuthServer : CDServer
    {
        public AuthServer(ServerConfig config) : base(config)
        {
        }

        protected override void OnConnect(Connection connection)
        {
            
        }
    }
}
