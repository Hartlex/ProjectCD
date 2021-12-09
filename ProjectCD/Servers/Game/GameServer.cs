﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server.Config;
using NetworkCommsDotNet.Connections;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.Servers.Channel;
using SunStructs.Packet.Auth;

namespace ProjectCD.Servers.Game
{
    internal class GameServer :CDServer
    {
        private readonly ChannelServer[] _channelServers;
        private readonly GameServerConfig _config;
        private readonly ChannelInfo[] _channelInfos;
        public GameServer(GameServerConfig config) : base(config)
        {
            _config = config;
            var channelCount = config.GetChannelCount();
            _channelServers = new ChannelServer[channelCount];
            _channelInfos = new ChannelInfo[channelCount];
            for (int i = 0; i < channelCount; i++)
            {
                var channelConfig = new ServerConfig(
                    new IPEndPoint(
                        config.GetIpEndPoint().Address,
                        config.GetPort() + i + 1
                    ),
                    config.GetAcceptedSessions(),
                    WorldPacketParser.Instance.ParsePacket
                );

                _channelServers[i] = new ChannelServer(channelConfig);
                _channelInfos[i] = new ChannelInfo("Ch " + i + 1, i, config.GetId());
            }

        }

        protected override void OnConnect(Connection connection)
        {
            
        }
    }
}