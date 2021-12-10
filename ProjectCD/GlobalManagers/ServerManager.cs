using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Connections;
using CD.Network.Server.Config;
using CDShared.Generics;
using ProjectCD.GlobalManagers.Config;
using ProjectCD.Objects.NetObjects;
using ProjectCD.Servers.Auth;
using ProjectCD.Servers.Game;
using SunStructs.PacketInfos.Auth.Client;
using SunStructs.PacketInfos.Auth.Server;

namespace ProjectCD.GlobalManagers
{
    internal class ServerManager :Singleton<ServerManager>
    {
        private AuthServer? _authServer;
        private Dictionary<byte,List<GameServer>>? _gameServers;
        private List<ServerInfo> _serverGroupInfo;
        private List<ChannelInfo> _channelInfos;
        public void Initialize()
        {
            _authServer = new AuthServer(ConfigManager.Instance.GetLoginServerConfig());
            _gameServers = new ();
            var configs = ConfigManager.Instance.GetGameServerConfigs();
            _serverGroupInfo = new (configs.Length);
            _channelInfos = new();
            foreach (var config in configs)
            {
                _gameServers.Add(config.GetId(),new ());
                _serverGroupInfo.Add(new (config.GetName(),config.GetId()));
                for(int i=0;i<config.GetChannelCount();i++)
                {
                    var serverConfig = new ServerConfig(
                        new IPEndPoint(config.GetIpEndPoint().Address, config.GetPort() + i),
                        config.GetAcceptedSessions(),
                        config.GetHandlePacket()
                    );
                    _gameServers[config.GetId()].Add(new (serverConfig));

                    _channelInfos.Add(new ChannelInfo("Channel "+(i+1),i,config.GetId()));
                }
            }

        }

        //private void HandleCloseConnection(Connection connection)
        //{
        //    ConnectionManager.Instance.RemoveConnection(connection);
        //}

        //private void HandleNewConnection(Connection connection)
        //{
        //    var endPoint = connection.ConnectionInfo.LocalEndPoint;
        //    if (Equals(endPoint, _authServer.GetLocalEndPoint()))
        //    {
        //        _authServer.OnConnect(connection);
        //        return;
        //    }
        //    foreach (var gameServerList in _gameServers)
        //    {
        //        foreach (var gameServer in gameServerList.Value)
        //        {
        //            if (Equals(endPoint, gameServer.GetLocalEndPoint()))
        //            {
        //                gameServer.OnConnect(connection);
        //                return;
        //            }
        //        }
        //    }

        //}

        public AnsServerListInfo GetServerListInfo()
        {
            return new (_serverGroupInfo.ToArray());
        }
        public AnsChannelListInfo GetChannelListInfo()
        {
            return new (_channelInfos.ToArray());
        }

        public bool CanUserJoin(AskServerSelectInfo info,Connection connection,User user,out IPEndPoint endPoint)
        {
            endPoint = null;
            if (!_gameServers.TryGetValue(info.ServerGroupId, out var list)) return false;

            try
            {
                var server = list[info.ChannelId];
                if (server.CanUserJoin(connection))
                {

                    endPoint = server.GetLocalEndPoint();
                    return true;
                }

                return false;
            }
            catch (IndexOutOfRangeException e)
            {
                return false;
            }
        }

    }
}
