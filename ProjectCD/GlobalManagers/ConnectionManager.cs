using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using CD.Network.Connections;
using CDShared.Generics;
using CDShared.Logging;
using Timer = System.Timers.Timer;

namespace ProjectCD.GlobalManagers
{
    internal class ConnectionManager : Singleton<ConnectionManager>
    {
        private readonly Dictionary<Guid, Connection> _activeConnections = new (10000);

        public void AddConnection(Connection connection)
        {

        }

        private void CheckConnection(Connection connection)
        {

        }

        public void RemoveConnection(Connection connection)
        {

        }


    }
}
