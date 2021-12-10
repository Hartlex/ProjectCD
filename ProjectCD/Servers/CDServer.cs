using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Connections;
using CD.Network.General;
using CD.Network.Server;
using CD.Network.Server.Config;
using ProjectCD.Objects.NetObjects;

namespace ProjectCD.Servers
{
    internal abstract class CDServer : CDServerBase
    {
        private readonly Dictionary<Guid,User> _connectedUsers = new ();
        private readonly Dictionary<byte[], User> _waitingList=new();
        protected CDServer(ServerConfig config) : base(config) {}

        public bool TryGetUser(Guid guid,out User? user)
        {
            return _connectedUsers.TryGetValue(guid, out user);
        }

        public bool TryAddUser(Guid guid, User user)
        {
            return _connectedUsers.TryAdd(guid, user);
        }

        public bool TryGetUser(Connection connection, out User? user)
        {
            return _connectedUsers.TryGetValue(connection.ID, out user);
        }

        public bool TryAddUser(Connection connection, User user)
        {
            return _connectedUsers.TryAdd(connection.ID, user);
        }

        public bool CanUserJoin(Connection connection)
        {
            if (!_connectedUsers.ContainsKey(connection.ID)) return true;

            return false;
        }

        public void PutOnWaitList(User user)
        {
            _waitingList.Add(user.GetClientSerial(),user);
        }

        public bool IsOnWaitList(byte[] serial,out User resultUser)
        {
            resultUser = null!;
            foreach (var (key, user) in _waitingList)
            {
                if (!key.SequenceEqual(serial)) continue;
                resultUser = user;
                return true;
            }

            return false;
        }

    }
}
