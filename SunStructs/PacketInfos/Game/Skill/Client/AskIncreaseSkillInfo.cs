using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Skill.Client
{
    public class AskIncreaseSkillInfo : ClientPacketInfo
    {
        public readonly byte IsSkill;
        public readonly ushort SkillCode;

        public AskIncreaseSkillInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            IsSkill = buffer.ReadByte();
            SkillCode = buffer.ReadUInt16();
        }
    }
}
