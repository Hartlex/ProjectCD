using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.Commands;
using ProjectCD.GlobalManagers;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using SunStructs.PacketInfos.World.Chat.Client;
using SunStructs.PacketInfos.World.Chat.Server;
using SunStructs.Packets;
using SunStructs.Packets.WorldServerPackets.Chat;

namespace ProjectCD.Servers.World.Actions
{
    public class ChatActions
    {
        private int _count;
        public ChatActions()
        {
            RegisterChatAction(137,OnAskPostChatMessage);
            Logger.Instance.LogOnLine($"[WORLD][CHAT] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private void RegisterChatAction(byte subType, Action<ByteBuffer, Connection> action)
        {
            WorldPacketParser.Instance.RegisterAction((byte)WorldPacketType.CHAT, subType, action);
            _count++;
        }
        private void OnAskPostChatMessage(ByteBuffer buffer, Connection connection)
        {
            var info = new AskPostChatInfo(ref buffer);
            var user = connection.User;
            if (info.Message.StartsWith("CMD:"))
            {
                CommandParser.Instance.ParseCommand(info.Message, user);
                return;
            }


            var charName = user.Player.GetName();
            var outInfo = new ChatMessageInfo(charName, info);
            var outPacket = new ChatPacket.AckPostChatMessage(outInfo);
            connection.Send(outPacket);

        }
    }
}
