using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Connections;
using CDShared.Generics;
using ProjectCD.Objects.NetObjects;

namespace ProjectCD.GlobalManagers
{
    internal class UserManager : Singleton<UserManager>
    {
        private Dictionary<Guid, User> _activeUsers = new();

        public User CreateUser(Connection authConnection,uint userID)
        {
            return null;
        }

        public bool TryGetUser(Connection connection,out User? user)
        {
            user = null;
            return false;
        }
    }
}
