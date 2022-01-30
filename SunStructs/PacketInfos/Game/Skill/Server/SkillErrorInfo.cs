using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace SunStructs.PacketInfos.Game.Skill.Server
{
    public class SkillErrorInfo : ServerPacketInfo
    {
        public readonly ushort SkillCode;
        public readonly byte ErrorCode;

        public SkillErrorInfo(ushort skillCode,SkillResult resultCode)
        {
            SkillCode = skillCode;
            ErrorCode = (byte) resultCode;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(SkillCode);
            buffer.WriteByte(ErrorCode);
        }
    }
}
