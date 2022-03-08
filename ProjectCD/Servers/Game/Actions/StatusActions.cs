using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using SunStructs.PacketInfos.Game.Status.Client;
using SunStructs.PacketInfos.Game.Status.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Status;
using static SunStructs.Packets.GameServerPackets.Status.StatusProtocol;

namespace ProjectCD.Servers.Game.Actions
{
    internal static class StatusActions
    {
        private static int _count;
        public static void Initialize()
        {
            RegisterStatusAction(ASK_INCREASE_ATTRIBUTE, OnAskIncreaseAttribute);

            Logger.Instance.LogOnLine($"[GAME][STATUS] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private static void RegisterStatusAction(StatusProtocol subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.STATUS, (byte)subType, action);
            _count++;
        }

        private static void OnAskIncreaseAttribute(ByteBuffer buffer, Connection connection)
        {
            var player = connection.User.Player;
            var info = new AskIncreaseAttribute(ref buffer);

            if (player.TryIncreaseBaseAttribute(info, out var newValue))
            {
                var packet = new AckIncreaseAttr(new (player.GetKey(), (byte) info.AttrType, newValue));
                connection.Send(packet);
            }
        }
    }
}
