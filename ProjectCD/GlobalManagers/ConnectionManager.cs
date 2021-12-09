using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using CDShared.Generics;
using CDShared.Logging;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Tools;
using Timer = System.Timers.Timer;

namespace ProjectCD.GlobalManagers
{
    internal class ConnectionManager : Singleton<ConnectionManager>
    {
        private readonly Dictionary<ShortGuid, Connection> _activeConnections = new (10000);

        public void AddConnection(Connection connection)
        {
            if (connection.ConnectionInfo.NetworkIdentifier == ShortGuid.Empty)
            {
                connection.ConnectionInfo.ResetNetworkIdentifer(ShortGuid.NewGuid());
                _activeConnections.Add(connection.ConnectionInfo.NetworkIdentifier,connection);
                Logger.Instance.Log($"Connection[{connection.ConnectionInfo.NetworkIdentifier}] added!", LogType.FULL);

                var timer = new Timer(5000);
                timer.AutoReset = false;
                timer.Elapsed += (sender, args) =>
                {
                    CheckConnection(connection);
                };
                timer.Start();
            }
        }

        private void CheckConnection(Connection connection)
        {
            if(connection.ConnectionInfo.ConnectionState != ConnectionState.Established) RemoveConnection(connection);
        }

        public void RemoveConnection(Connection connection)
        {
            if (_activeConnections.ContainsKey(connection.ConnectionInfo.NetworkIdentifier))
            {
                _activeConnections.Remove(connection.ConnectionInfo.NetworkIdentifier);
                Logger.Instance.Log($"Connection[{connection.ConnectionInfo.NetworkIdentifier}] removed!",LogType.FULL);

            }
        }


    }
}
