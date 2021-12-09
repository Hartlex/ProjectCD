using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server.Config;
using NetworkCommsDotNet.Connections;
using ProjectCD.GlobalManagers;

namespace ProjectCD.Servers.Auth
{
    internal sealed class AuthServer : CDServer
    {
        public AuthServer(LoginServerConfig config) : base(config)
        {
        }

        public override void OnConnect(Connection connection)
        {
            ConnectionManager.Instance.AddConnection(connection);
        }
    }
}
