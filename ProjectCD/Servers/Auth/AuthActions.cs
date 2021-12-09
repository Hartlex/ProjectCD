﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Generics;
using CDShared.Logging;
using NetworkCommsDotNet.Connections;
using ProjectCD.GlobalManagers;
using ProjectCD.GlobalManagers.Config;
using ProjectCD.GlobalManagers.DB;
using ProjectCD.GlobalManagers.PacketParsers;
using SunStructs.PacketInfos.Auth.Client;
using SunStructs.PacketInfos.Auth.Server;
using SunStructs.Packets;
using SunStructs.Packets.AuthServerPackets;
using static SunStructs.Definitions.AuthResultType;
using static SunStructs.Definitions.PacketResultType;

namespace ProjectCD.Servers.Auth
{
    internal class AuthActions : Singleton<AuthActions>
    {
        public void Initialize()
        {
            RegisterAuthAction(1, OnAskConnect);
            RegisterAuthAction(3, OnAskLogin);
            RegisterAuthAction(15, OnAskServerList);
            RegisterAuthAction(19, OnAskServerSelect);
        }
        private void RegisterAuthAction(byte subType, Action<ByteBuffer, Connection> action)
        {
            AuthPacketParser.Instance.RegisterAction((byte)AuthPacketType.AUTH,subType,action);
        }
        private void OnAskConnect(ByteBuffer buffer, Connection connection)
        {
            var info = new AskConnectInfo(ref buffer);
            var compatible = ConfigManager.Instance.IsClientVersionCompatible(info.ClientVersion);
            var packet = new AckConnect(new(compatible ? PACKET_RESULT_SUCCESS : PACKET_RESULT_FAIL));
            connection.SendUnmanagedBytes(packet.GetBytes());
#if DEBUG
            if(!compatible)
                Logger.Instance.Log($"Connection[{connection.ConnectionInfo.NetworkIdentifier}] " +
                                $"tried to connect from an incompatible client!\n" +
                                $"EndPoint[{connection.ConnectionInfo.RemoteEndPoint}]");
#endif

        }

        private void OnAskLogin(ByteBuffer buffer, Connection connection)
        {
            var info = new AskLoginInfo(ref buffer, 0);
            var result = Database.Instance.CheckLoginInfo(info, out var userID);
            if(result == AUTH_RESULT_OK) 
                UserManager.Instance.CreateUser(connection, userID);
            var outInfo = new AckLoginInfo(result, 0, "Test Info", 0);
            var outPacket = new AckLogin(outInfo);
            connection.SendUnmanagedBytes(outPacket.GetBytes());
        }

        private void OnAskServerList(ByteBuffer buffer, Connection connection)
        {
            var serverInfo = ServerManager.Instance.GetServerListInfo();
            var channelInfo = ServerManager.Instance.GetChannelListInfo();

            var serverPacket = new AnsServerList(serverInfo);
            var channelPacket = new AnsChannelList(channelInfo);

            connection.SendUnmanagedBytes(serverPacket.GetBytes());
            connection.SendUnmanagedBytes(channelPacket.GetBytes());
        }

        private void OnAskServerSelect(ByteBuffer buffer, Connection connection)
        {
            var info = new AskServerSelectInfo(ref buffer);
            if (UserManager.Instance.TryGetUser(connection, out var user))
            {
                if (ServerManager.Instance.UserCanConnect(info))
                {

                }
                var serial = user.GetClientSerial();
                var logKey = new byte[] {0x33, 0x36, 0x65, 0x36, 0x65, 0x6b, 0x6f, 0x37, 0x00};

            }


            var outInfo = new AckServerSelectInfo()
        }
    }
}