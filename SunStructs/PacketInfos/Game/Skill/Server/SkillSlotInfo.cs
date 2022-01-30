using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Skill.Server
{
    public class SkillSlotInfo : ServerPacketInfo
    {
        public readonly byte Pos;
        public readonly ushort SkillCode;

        public SkillSlotInfo(byte pos, ushort skillCode)
        {
            this.Pos = pos;
            SkillCode = skillCode;
        }


        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Pos);
            buffer.WriteUInt16(SkillCode);
        }
    }
}
