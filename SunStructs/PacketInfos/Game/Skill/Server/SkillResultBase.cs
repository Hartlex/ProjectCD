using System.Text;
using CDShared.ByteLevel;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Skill.Server
{
    public class SkillResultBase : ServerPacketInfo
    {
        public readonly uint TargetKey;
        public byte EffectCount;
        public byte AbilityCount;
        public SkillResultEffect[] SkillResultEffects;
        public SkillResultAbility[] SkillResultAbility;
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(TargetKey);
            byte b = 0;
            b = BitManip.Set0to4(b, EffectCount);
            b = BitManip.Set5to7(b, AbilityCount);
            buffer.WriteByte(b);
            if (EffectCount > 0)
                foreach (var skillResultEffect in SkillResultEffects)
                {
                    skillResultEffect.GetBytes(ref buffer);
                }

            if (AbilityCount > 0)
                foreach (var skillResultAbility in SkillResultAbility)
                {
                    skillResultAbility.GetBytes(ref buffer);
                }
        }

        public SkillResultBase(uint targetKey)
        {
            TargetKey = targetKey;
            EffectCount = 0;
            AbilityCount = 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var b in GetBytes())
            {
                sb.Append(b + "|");
            }

            return sb.ToString();
        }
    }

    public class SkillResultEffect : ServerPacketInfo
    {
        public readonly ushort AbilityOrder;
        public readonly SunVector CurrentPosition;

        public SkillResultEffect(ushort abilityOrder, SunVector currentPosition)
        {
            AbilityOrder = abilityOrder;
            CurrentPosition = currentPosition;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(AbilityOrder);
            CurrentPosition.GetBytes(ref buffer);
        }
    }

    public class SkillResultAbility : ServerPacketInfo
    {
        public ushort AbilityOrder;
        public ushort AbilityCode;
        public uint AbilityDuration;


        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(AbilityOrder);
            buffer.WriteUInt16(AbilityCode);
            buffer.WriteUInt32(AbilityDuration);
        }
    }

    public class SkillResultDmg : SkillResultAbility
    {
        //public ushort Unk0;
        //public uint Unk1;
        public ushort Damage;
        public uint TargetHp;
        public byte Effect; //Crit

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            buffer.WriteUInt16(Damage);
            buffer.WriteUInt32(TargetHp);
            buffer.WriteByte(Effect);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var b in GetBytes())
            {
                sb.Append(b + "|");
            }

            return sb.ToString();
        }
    }

    public class SkillResultAbnStatus : SkillResultAbility
    {
        public SunVector CurrentPosition;

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            CurrentPosition.GetBytes(ref buffer);
        }
    }

    public class SkillResultKnockBack : SkillResultAbility
    {
        public SunVector CurrentPosition;
        public SunVector DestinationPosition;

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            CurrentPosition.GetBytes(ref buffer);
            DestinationPosition.GetBytes(ref buffer);
        }
    }

    public class SkillResultExhaust : SkillResultAbility
    {
        public uint TargetHP;
        public uint TargetMP;
        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            buffer.WriteUInt32(TargetHP);
            buffer.WriteUInt32(TargetMP);
        }
    }

    public class SkillResultFightEnergy : SkillResultAbility
    {
        public ushort FightingEnergy;

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            buffer.WriteUInt16(FightingEnergy);
        }
    }

    public class SkillResultResurrection : SkillResultAbility
    {
        public SunVector Position;
        public uint TargetHP;
        public uint TargetMP;

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            Position.GetBytes(ref buffer);
            buffer.WriteUInt32(TargetHP);
            buffer.WriteUInt32(TargetMP);
        }
    }
}
