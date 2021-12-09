using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server;
using CD.Network.Server.Config;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Tools;
using ProjectCD.Objects.NetObjects;

namespace ProjectCD.Servers
{
    internal abstract class CDServer : CDServerBase
    {
        private readonly Dictionary<ShortGuid,User> _connectedUsers = new ();
        protected CDServer(ServerConfig config) : base(config) {}

        public bool TryGetUser(ShortGuid guid,out User? user)
        {
            return _connectedUsers.TryGetValue(guid, out user);
        }

        public bool TryAddUser(ShortGuid guid, User user)
        {
            return _connectedUsers.TryAdd(guid, user);
        }

        public bool TryGetUser(Connection connection, out User? user)
        {
            return _connectedUsers.TryGetValue(connection.ConnectionInfo.NetworkIdentifier, out user);
        }

        public bool TryAddUser(Connection connection, User user)
        {
            return _connectedUsers.TryAdd(connection.ConnectionInfo.NetworkIdentifier, user);
        }

    }
}
