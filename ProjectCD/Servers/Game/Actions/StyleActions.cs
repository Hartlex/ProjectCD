using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Status.Client;
using SunStructs.PacketInfos.Game.Status.Server;
using SunStructs.PacketInfos.Game.Style.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Status;
using SunStructs.Packets.GameServerPackets.Style;
using static SunStructs.Packets.GameServerPackets.Status.StatusProtocol;
using static SunStructs.Packets.GameServerPackets.Style.StyleProtocol;

namespace ProjectCD.Servers.Game.Actions
{
    internal static class StyleActions
    {
        private static int _count;
        public static void Initialize()
        {
            RegisterStyleAction(ASK_CHANGE_STYLE, OnAskSelectStyle);

            Logger.Instance.LogOnLine($"[GAME][STYLE] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private static void RegisterStyleAction(StyleProtocol subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.STYLE, (byte)subType, action);
            _count++;
        }

        private static void OnAskSelectStyle(ByteBuffer buffer, Connection connection)
        {
            var player = connection.User.Player;
            var style = (StyleEnum)buffer.ReadUInt16();
            player.SetSelectedStyle(style);
        }
    }
}
