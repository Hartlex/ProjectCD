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
        ATTR_CHANGE_BRD = 157,
        CHANGE_HP = 16,
        CHANGE_MP = 50,
        CHANGE_CONDITION_BRD = 63
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
    public class StatusRecoverHpBrd : StatusPacket
    {
        public StatusRecoverHpBrd(ChangeHPInfo info) : base(CHANGE_HP, info) { }
    }
    public class StatusRecoverMpBrd : StatusPacket
    {
        public StatusRecoverMpBrd(ChangeMPInfo info) : base(CHANGE_MP, info) { }
    }
    public class ChangConditionBRD : StatusPacket
    {
        public ChangConditionBRD(ChangeConditionInfo info) : base(CHANGE_CONDITION_BRD, info) { }
    }
}
