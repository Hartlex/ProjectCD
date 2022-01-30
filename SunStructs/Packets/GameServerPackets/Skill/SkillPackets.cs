using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Skill.Server;
using static SunStructs.Packets.GameServerPackets.Skill.SkillProtocol;

namespace SunStructs.Packets.GameServerPackets.Skill
{
    public enum SkillProtocol
    {
        INSTANT_RESULT_BRD = 133,
        DELAY_RESULT_START_BRD = 146,
        DELAY_RESULT_END_BRD = 189,
        ASK_INCREASE_SKILL = 197,
        ACK_INCREASE_SKILL = 85,
        ASK_USE_SKILL = 46,
        PERIODIC_DMG_BRD = 148
    }
    public class SkillPacket : Packet
    {
        public SkillPacket(SkillProtocol packetSubType, ServerPacketInfo packetStruct) : base((byte) GamePacketType.SKILL, (byte) packetSubType, packetStruct)
        {
        }
    }
    public class SkillInstantResultBRD : SkillPacket
    {
        public SkillInstantResultBRD(InstantSkillResultInfo info) : base(INSTANT_RESULT_BRD, info) { }
    }
    public class SkillDelayStartBRD : SkillPacket
    {
        public SkillDelayStartBRD(ActionDelayStartInfo info) : base(DELAY_RESULT_START_BRD, info) { }
    }
    public class SkillDelayResultBRD : SkillPacket
    {
        public SkillDelayResultBRD(ActionDelayResultInfo info) : base(DELAY_RESULT_END_BRD, info) { }
    }
    public class AckIncreaseSkill : SkillPacket
    {
        public AckIncreaseSkill(AckIncreaseSkillInfo info) : base(ACK_INCREASE_SKILL, info) { }

    }
    public class PeriodicDamageBRD : SkillPacket
    {
        public PeriodicDamageBRD(PeriodicDmgInfo info) : base(PERIODIC_DMG_BRD, info) { }
    }
}
