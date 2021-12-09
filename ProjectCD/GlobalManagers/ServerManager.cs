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
using SunStructs.PacketInfos.Auth.Client;
using SunStructs.PacketInfos.Auth.Server;

namespace ProjectCD.GlobalManagers
{
    internal class ServerManager :Singleton<ServerManager>
    {
        private AuthServer? _authServer;
        private Dictionary<int,GameServer>? _gameServers;
        private Dictionary<int,ChannelServer>? _channelServers;
        public void Initialize()
        {
            _authServer = new AuthServer(ConfigManager.Instance.GetLoginServerConfig());
            _gameServers = new ();
            _channelServers = new ();
            var configs = ConfigManager.Instance.GetGameServerConfigs();
            foreach (var config in configs)
            {
                var gameServer = new GameServer(config);
                _gameServers.Add(config.GetId(),gameServer);
                var channelServers = gameServer.GetChannelServers();
                for (var i = 0; i < channelServers.Length; i++)
                {
                    _channelServers.Add(i,channelServers[i]);
                }
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

        public AnsServerListInfo GetServerListInfo()
        {
            var result = new ServerInfo[_gameServers.Count];
            for (int i = 0; i < _gameServers.Count; i++)
            {
                result[i] = _gameServers[i].GetServerInfoForClient();
            }
            return new (result);
        }
        public AnsChannelListInfo GetChannelListInfo()
        {
            var result = new List<ChannelInfo>();
            foreach (var gameServer in _gameServers)
            {
                result.AddRange(gameServer.Value.GetChannelInfosForClient());
            }

            return new (result.ToArray());
        }

        public bool UserCanConnect(AskServerSelectInfo info)
        {
            
        }
    }
}
