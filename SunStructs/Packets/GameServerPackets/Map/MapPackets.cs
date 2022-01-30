using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Map.Server;
using static SunStructs.Packets.GameServerPackets.Map.MapProtocol;

namespace SunStructs.Packets.GameServerPackets.Map
{
    public enum MapProtocol
    {
        OBJECT_TELEPORT_BRD = 179
    }
    public class MapPacket : Packet
    {
        public MapPacket(MapProtocol packetSubType, ServerPacketInfo packetStruct) : base((byte) GamePacketType.MAP, (byte) packetSubType, packetStruct)
        {

        }
    }

    public class ObjectTeleportCMD : MapPacket
    {
        public ObjectTeleportCMD(ObjectTeleportInfo info) : base(OBJECT_TELEPORT_BRD, info) { }
    }
}
