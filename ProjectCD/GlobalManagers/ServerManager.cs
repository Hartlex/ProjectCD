using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server.Config;
using CDShared.Generics;
using ProjectCD.GlobalManagers.Config;
using ProjectCD.NetworkBase.Connections;
using ProjectCD.Objects.NetObjects;
using ProjectCD.Servers.Auth;
using ProjectCD.Servers.Game;
using SunStructs.PacketInfos.Auth.Client;
using SunStructs.PacketInfos.Auth.Server;
using SunStructs.PacketInfos.Game.Connection;

namespace ProjectCD.GlobalManagers
{
    internal class ServerManager :Singleton<ServerManager>
    {
        private AuthServer? _authServer;
        private Dictionary<byte,List<GameServer>>? _gameServers;
        private List<ServerInfo> _serverGroupInfo;
        private List<ChannelInfo> _channelInfos;

        private Dictionary<uint, GameServer> _gameServersWaitList = new();

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

        public AnsServerListInfo GetServerListInfo()
        {
            return new (_serverGroupInfo.ToArray());
        }
        public AnsChannelListInfo GetChannelListInfo()
        {
            return new (_channelInfos.ToArray());
        }

        public bool CanUserJoin(AskServerSelectInfo info,User user,out IPEndPoint endPoint)
        {
            endPoint = null;
            if (!_gameServers.TryGetValue(info.ServerGroupId, out var list)) return false;

            try
            {
                var server = list[info.ChannelId];
                if (server.CanUserJoin(user))
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

        public bool PutOnWaitList(AskServerSelectInfo info, User user)
        {
            if (!_gameServers.TryGetValue(info.ServerGroupId, out var list)) return false;

            try
            {
                var server = list[info.ChannelId];
                server.PutOnWaitList(user);
                _gameServersWaitList.Add(user.UserID,server);

                return false;
            }
            catch (IndexOutOfRangeException e)
            {
                return false;
            }
        }

        public bool TryEnterGameServer(AskEnterCharSelectInfo info,Connection connection, out User user)
        {
            user = null;
            if (!_gameServersWaitList.TryGetValue(info.UserId, out var server)) return false;
            if (!server.IsOnWaitList(info.ClientSerial, out user)) return false;
            if (!server.TryAddUser(user)) return false;
            connection.AppendCloseHandler((con) =>
            {
                server.RemoveUser(info.UserId);
            });
            _gameServersWaitList.Remove(user.UserID);
            user.SetGameServerConnection(connection);
            user.SetState(UserConnectionState.AT_CHAR_SELECT);
            connection.OnGameServerConnect(user);
            return true;
        }

    }
}
