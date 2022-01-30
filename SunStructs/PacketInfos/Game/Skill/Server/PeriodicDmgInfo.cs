using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Skill.Server
{
    public class PeriodicDmgInfo : ServerPacketInfo
    {
        public readonly uint AttackerKey;
        public readonly ushort SkillCode;
        public readonly byte NumberOfTargets;
        public readonly DamageInfo[] DamageInfos;

        public PeriodicDmgInfo(uint attackerKey, ushort skillCode, byte numberOfTargets)
        {
            AttackerKey = attackerKey;
            SkillCode = skillCode;
            NumberOfTargets = numberOfTargets;
            DamageInfos = new DamageInfo[numberOfTargets];
        }

        public PeriodicDmgInfo(uint attackerKey, ushort skillCode, DamageInfo[] infos)
        {           
            AttackerKey = attackerKey;
            SkillCode = skillCode;
            NumberOfTargets = (byte) infos.Length;
            DamageInfos = infos;

        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(AttackerKey);
            buffer.WriteUInt16(SkillCode);
            buffer.WriteByte(NumberOfTargets);
            foreach (var damageInfo in DamageInfos)
            {
                damageInfo.GetBytes(ref buffer);
            }
        }
    }
}
