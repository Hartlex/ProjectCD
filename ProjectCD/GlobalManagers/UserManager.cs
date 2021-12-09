using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Tools;
using ProjectCD.Objects.NetObjects;

namespace ProjectCD.GlobalManagers
{
    internal class UserManager : Singleton<UserManager>
    {
        private Dictionary<ShortGuid, User> _activeUsers = new();

        public User CreateUser(Connection authConnection,uint userID)
        {
            var user = new User(userID,authConnection);
            _activeUsers.Add(authConnection.ConnectionInfo.NetworkIdentifier,user);
            return user;
        }

        public bool TryGetUser(Connection connection,out User? user)
        {
            return _activeUsers.TryGetValue(connection.ConnectionInfo.NetworkIdentifier, out user);
        }
    }
}
