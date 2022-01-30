using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Skill.Server
{
    public class AckIncreaseSkillInfo : ServerPacketInfo
    {
        public readonly ushort OldSkillCode;
        public readonly SkillSlotInfo NewSlotInfo;
        public readonly ushort RemainSkillPoints;

        public AckIncreaseSkillInfo(ushort oldSkillCode, SkillSlotInfo newSlotInfo, ushort remainSkillPoints)
        {
            OldSkillCode = oldSkillCode;
            NewSlotInfo = newSlotInfo;
            RemainSkillPoints = remainSkillPoints;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(OldSkillCode);
            buffer.WriteBlock(NewSlotInfo.GetBytes());
            buffer.WriteUInt32(RemainSkillPoints);
        }
    }
}
