using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Skill.Server
{
    public class DamageInfo : ServerPacketInfo
    {
        public readonly uint TargetKey;
        public readonly ushort Damage;
        public readonly uint TargetHP;

        public DamageInfo(uint targetKey, ushort damage, uint targetHP)
        {
            TargetKey = targetKey;
            Damage = damage;
            TargetHP = targetHP;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(TargetKey);
            buffer.WriteUInt16(Damage);
            buffer.WriteUInt32(TargetHP);
        }
    }
}