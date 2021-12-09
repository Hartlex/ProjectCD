using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Generics;
using NetworkCommsDotNet.Connections;
using ProjectCD.GlobalManagers.PacketParsers;
using SunStructs.Packets;

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

        }
        private void OnAskLogin(ByteBuffer buffer, Connection connection){}
        private void OnAskServerList(ByteBuffer buffer,Connection connection){}
        private void OnAskServerSelect(ByteBuffer buffer,Connection connection){}
    }
}
