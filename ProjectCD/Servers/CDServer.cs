using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server;
using CD.Network.Server.Config;
using CDShared.Logging;
using ProjectCD.NetworkBase.Connections;
using ProjectCD.NetworkBase.General;
using ProjectCD.Objects.NetObjects;

namespace ProjectCD.Servers
{
    public abstract class CDServer : CDServerBase
    {
        private readonly Dictionary<uint,User> _connectedUsers = new ();
        private readonly Dictionary<byte[], User> _waitingList=new();
        protected CDServer(ServerConfig config) : base(config) {}

        public bool TryGetUser(uint userID,out User? user)
        {
            return _connectedUsers.TryGetValue(userID, out user);
        }

        public bool TryAddUser( User user)
        {
            return _connectedUsers.TryAdd(user.UserID, user);
        }

        public void RemoveUser(User user)
        {
            RemoveUser(user.UserID);
        }
        public void RemoveUser(uint userID)
        {
            if (_connectedUsers.ContainsKey(userID))
            {
                _connectedUsers.Remove(userID);
#if DEBUG
                Logger.Instance.Log($"[{GetType().Name}] removed User[{userID}]");
#endif
            }
        }
        public bool CanUserJoin(User user)
        {
            if (!_connectedUsers.ContainsKey(user.UserID)) return true;

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
