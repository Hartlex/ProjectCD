using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using ProjectCD.GlobalManagers.Config;
using ProjectCD.Servers.Auth;
using ProjectCD.Servers.Channel;
using ProjectCD.Servers.Game;

namespace ProjectCD.GlobalManagers
{
    internal class ServerManager :Singleton<ServerManager>
    {
        private AuthServer? _authServer;
        private List<GameServer>? _gameServers;
        private List<ChannelServer>? _channelServers;
        public void Initialize()
        {
            _authServer = new AuthServer(ConfigManager.Instance.GetLoginServerConfig());
            _gameServers = new List<GameServer>();
            _channelServers = new List<ChannelServer>();
            var configs = ConfigManager.Instance.GetGameServerConfigs();
            foreach (var config in configs)
            {
                var gameServer = new GameServer(config);
                _gameServers.Add(gameServer);
                _channelServers.AddRange(gameServer.GetChannelServers());

            }

            NetworkComms.AppendGlobalConnectionEstablishHandler(HandleNewConnection);
            NetworkComms.AppendGlobalConnectionCloseHandler(HandleCloseConnection);
        }

        private void HandleCloseConnection(Connection connection)
        {
            ConnectionManager.Instance.RemoveConnection(connection);
        }

        private void HandleNewConnection(Connection connection)
        {
            var endPoint = connection.ConnectionInfo.LocalEndPoint;
            if (Equals(endPoint, _authServer.GetLocalEndPoint()))
            {
                _authServer.OnConnect(connection);
                return;
            }
            foreach (var gameServer in _gameServers)
            {
                if (!Equals(endPoint, gameServer.GetLocalEndPoint())) continue;
                gameServer.OnConnect(connection);
                return;
            }
            foreach (var channelServer in _channelServers)
            {
                if (!Equals(endPoint, channelServer.GetLocalEndPoint())) continue;
                channelServer.OnConnect(connection);
                return;
            }
        }
    }
}
