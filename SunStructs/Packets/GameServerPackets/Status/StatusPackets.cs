using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Status.Server;
using static SunStructs.Packets.GameServerPackets.Status.StatusProtocol;

namespace SunStructs.Packets.GameServerPackets.Status
{
    public enum StatusProtocol
    {
        ATTR_CHANGE_BRD = 157
    }
    public class StatusPacket : Packet
    {
        public StatusPacket(StatusProtocol packetSubType, ServerPacketInfo serverInfo) : base((byte) GamePacketType.STATUS, (byte)packetSubType, serverInfo)
        {
        }
    }

    public class AttrChangeBrd : StatusPacket
    {
        public AttrChangeBrd(AttrChangeInfo info) : base(ATTR_CHANGE_BRD, info) { }
    }
}
