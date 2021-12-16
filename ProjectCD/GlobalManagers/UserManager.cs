using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.NetworkBase.Connections;
using ProjectCD.Objects.NetObjects;

namespace ProjectCD.GlobalManagers
{
    internal class UserManager : Singleton<UserManager>
    {
        private readonly Dictionary<uint, User> _activeUsers = new();

        public User CreateUser(uint userID)
        {
            var user = new User(userID);
            AddUser(user,AddUserType.CREATION);
            return user;
        }

        public bool TryGetUser(uint userID,out User user)
        {
            return _activeUsers.TryGetValue(userID, out user);
        }

        public void AddUser(User user,AddUserType type)
        {
            _activeUsers.TryAdd(user.UserID, user);
#if DEBUG
            Logger.Instance.Log($"[{GetType().Name}] User[{user.UserID}] added! (Reason: {type})",LogType.FULL);
#endif
        }
        public void RemoveUser(User user, RemoveUserType type)
        {
            if (_activeUsers.ContainsKey(user.UserID))
            {
                _activeUsers.Remove(user.UserID);
#if DEBUG
                Logger.Instance.Log($"[{GetType().Name}] User[{user.UserID}] removed! (Reason: {type})",LogType.FULL);
#endif
            }
        }

        public bool TryGetUser(Connection otherConnection, out User? user)
        {
            foreach (var activeUser in _activeUsers.Values)
            {
                if (!(activeUser.GetGameServerConnection().workSocket.RemoteEndPoint is IPEndPoint gameEndPoint)) continue;
                if (!(otherConnection.workSocket.RemoteEndPoint is IPEndPoint endPoint)) continue;
                if (Equals(endPoint.Address, gameEndPoint.Address))
                {
                    user = activeUser;
                    return true;
                }
            }

            user = null;
            return false;
        }
    }
    public enum RemoveUserType{
        FROM_LOGIN,
        FROM_GAME
    }
    public enum AddUserType{
        CREATION,
        FROM_LOGIN,
        FROM_GAME
    }
}
