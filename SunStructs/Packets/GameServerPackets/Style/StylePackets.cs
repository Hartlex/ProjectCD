using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Style.Server;
using static SunStructs.Packets.GameServerPackets.Style.StyleProtocol;

namespace SunStructs.Packets.GameServerPackets.Style
{
    public enum StyleProtocol{
        STYLE_ATTACK_RESULT =41,
        STYLE_ATTACK_BRD = 198,
        STYLE_CHANGE_BRD = 95
    }
    public class StylePacket : Packet
    {
        public StylePacket(StyleProtocol packetSubType, ServerPacketInfo packetStruct) : base((byte) GamePacketType.STYLE, (byte) packetSubType, packetStruct)
        {
        }
    }
    public class StyleAttackResultBRD : StylePacket
    {
        public StyleAttackResultBRD(StylePlayerAttackResultInfo info) : base(STYLE_ATTACK_RESULT, info) { }
    }

    public class StyleAttackBRD : StylePacket
    {
        public StyleAttackBRD(StylePlayerAttackInfo info) : base(STYLE_ATTACK_BRD, info) { }
    }
    public class ChangeStyleBRD : StylePacket
    {
        public ChangeStyleBRD(ChangeStyleInfo info) : base(STYLE_CHANGE_BRD, info) { }
    }
}
