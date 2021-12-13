using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Quest.Server;

namespace SunStructs.Packets.GameServerPackets.Quest
{
    public class QuestPacket : Packet
    {
        public QuestPacket(byte packetSubType, ServerPacketInfo info) : base((byte)GamePacketType.QUEST, packetSubType, info)
        {
        }
    }
    public class QuestListCmd : QuestPacket
    {
        public QuestListCmd(QuestListInfo info) : base(35, info) { }
    }
}
