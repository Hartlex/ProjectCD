using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Zone.Server;

namespace SunStructs.Packets.GameServerPackets.Zone
{
    public class ZonePacket : Packet
    {
        public ZonePacket(byte packetSubType, ServerPacketInfo info) : base((byte) GamePacketType.ZONE, packetSubType, info)
        {

        }
    }
    public class AckZoneMove : ZonePacket
    {
        public AckZoneMove(AckZoneMoveInfo info) : base(108, info) { }
    }
}
