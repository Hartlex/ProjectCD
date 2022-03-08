using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server.Config;
using CDShared.Logging;
using ProjectCD.GlobalManagers;
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
            if(UserManager.Instance.TryGetUser(connection,out var user))
            {
                connection.OnWorldServerConnect(user!);
                Logger.Instance.Log($"User[{user!.UserID}] connected to WorldServer");
            }
            else
            {
                Logger.Instance.Log($"Unknown user connected to WorldServer");
                connection.workSocket.Shutdown(SocketShutdown.Receive);
            }
        }
    }
}
