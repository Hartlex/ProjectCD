using CDShared.ByteLevel;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.Slots.Skill
{
    public class SkillSlot
    {
        public readonly byte Pos;
        public RootSkillInfo RootSkillInfo;
        public SkillSlot(byte pos, ushort code)
        {
            Pos = pos;
            RootSkillInfo = BaseSkillDB.Instance.GetRootSkillInfo(code);
        }
        public SkillSlot(ref ByteBuffer buffer)
        {
            Pos = buffer.ReadByte();
            var skillCode = buffer.ReadUInt16();
            RootSkillInfo = BaseSkillDB.Instance.GetRootSkillInfo(skillCode);
        }
        public SkillSlot(byte pos,RootSkillInfo info)
        {
            Pos = pos;
            RootSkillInfo = info;
        }
        public SkillSlotInfo GetSlotInfo()
        {
            return new SkillSlotInfo(Pos, RootSkillInfo.SkillCode);
        }
        public void GetBytes(ref ByteBuffer buffer)
        {
            if(RootSkillInfo ==null) return;
            buffer.WriteByte(Pos);
            buffer.WriteUInt16(RootSkillInfo.SkillCode);
        }
    }
}