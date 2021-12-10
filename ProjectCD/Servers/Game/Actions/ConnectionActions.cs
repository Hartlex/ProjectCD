using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.GlobalManagers;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using SunStructs.PacketInfos.Game.Connection;
using SunStructs.Packets;

namespace ProjectCD.Servers.Game.Actions
{
    internal class ConnectionActions
    {
        public  ConnectionActions()
        {
            RegisterConnectionAction(118,OnAskEnterCharSelect);
        }
        private void RegisterConnectionAction(byte subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.CONNECTION, subType, action);
        }


        private void OnAskEnterCharSelect(ByteBuffer buffer, Connection connection)
        {
            var info = new AskEnterCharSelectInfo(ref buffer);
            if (ServerManager.Instance.TryEnterGameServer(info, connection, out var user))
            {
                UserManager.Instance.AddUser(user,AddUserType.FROM_GAME);
                connection.AppendCloseHandler((con) =>
                {
                    UserManager.Instance.RemoveUser(user,RemoveUserType.FROM_GAME);
                });
            }
        }
    }
}
