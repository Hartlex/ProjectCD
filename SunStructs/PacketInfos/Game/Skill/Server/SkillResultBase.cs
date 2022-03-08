using System.Text;
using CDShared.ByteLevel;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Skill.Server
{
    public class SkillResultBase : ServerPacketInfo
    {
        public readonly uint TargetKey;
        //public byte EffectCount;
        public byte AbilityCount;

        public byte SkillEffect;
        //public SkillResultEffect[] SkillResultEffects;
        public SkillResultAbility[] SkillResultAbility;
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(TargetKey);
            byte b = 0;
            b = BitManip.Set0to4(b, SkillEffect);
            b = BitManip.Set5to7(b, AbilityCount);
            buffer.WriteByte(b);


            var buf = new ByteBuffer();
            //buf.WriteUInt16(1);
            //buf.WriteUInt16(0);
            //buf.WriteUInt32(0);
            //buf.WriteUInt16(5);
            //buf.WriteUInt32(170);
            //buf.WriteByte(5);
            //buf.WriteBlock(new byte[]
            //{
            //    1,0,
            //    0,0,
            //    0,0,0,0,
            //    100,0,
            //    0,0,0,0,
            //    0
            //});
            buffer.WriteBlock(buf.GetData());
            //public ushort AbilityOrder;
            //public ushort AbilityCode;
            //public uint AbilityDuration;
            //public ushort Damage;
            //public uint TargetHp;
            //public byte Effect; //Crit

            for (int i = 0; i < AbilityCount; i++)
            {
                SkillResultAbility[i].GetBytes(ref buffer);
            }




            //for (int i = 0; i < EffectCount; i++)
            //{
            //    SkillResultEffects[i].GetBytes(ref buffer);
            //}
            //b = BitManip.Set0to2(b, AbilityCount);
            //b = BitManip.Set3to7(b, EffectCount);
            //buffer.WriteByte(b);
            //for (int i = 0; i < AbilityCount; i++)
            //{
            //    SkillResultAbility[i].GetBytes(ref buffer);
            //}

            //for (int i = 0; i < EffectCount; i++)
            //{
            //    SkillResultEffects[i].GetBytes(ref buffer);
            //}


        }

        public SkillResultBase(uint targetKey)
        {
            TargetKey = targetKey;
            //EffectCount = 0;
            AbilityCount = 0;
            SkillResultAbility = new SkillResultAbility[7];
            //SkillResultEffects = new SkillResultEffect[31];
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

    public class EffectInfo :ServerPacketInfo
    {
        public uint Time;
        public SunVector Position;
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(Time);
            Position.GetBytes(ref buffer);
        }
    }
    public class SkillResultEffect : ServerPacketInfo
    {
        public ushort AbilityOrder;
        public byte Count;
        public EffectInfo[] EffectInfos = new EffectInfo[Const.MAX_EFFECT_COUNT_INTERNAL];

        
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(AbilityOrder);
            buffer.WriteByte(Count);
            for (int i = 0; i < Count; i++)
            {
                EffectInfos[i].GetBytes(ref buffer);
            }
        }
    }

    public class SkillResultAbility : ServerPacketInfo
    {
        public ushort AbilityOrder;
        public ushort AbilityCode;
        public uint AbilityDuration;

        public SkillResultAbility(){}
        public SkillResultAbility(SkillResultAbility info)
        {
            AbilityOrder = info.AbilityOrder;
            AbilityCode = info.AbilityCode;
            AbilityDuration = info.AbilityDuration;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(AbilityOrder);
            buffer.WriteUInt16(AbilityCode);
            buffer.WriteUInt32(AbilityDuration);
        }
    }

    public class EmptyResult : SkillResultAbility
    {
        public override void GetBytes(ref ByteBuffer buffer)
        {
        }
    }

    public class SkillResultDmg : SkillResultAbility
    {
        //public ushort Unk0;
        //public uint Unk1;
        public ushort Damage;
        public uint TargetHp;
        public byte Effect; //Crit

        public SkillResultDmg(SkillResultAbility abilityResult) : base(abilityResult) { }

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

    public class SkillResultStun : SkillResultAbility
    {
        public SunVector CurrentPosition;
        public SkillResultStun(){}
        public SkillResultStun(SkillResultAbility baseInfo) : base(baseInfo) { }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            CurrentPosition.GetBytes(ref buffer);
        }
    }

    public class SkillResultPosition : SkillResultAbility
    {
        public SunVector CurrentPosition;
        public SunVector DestinationPosition;

        public SkillResultPosition()
        {
            CurrentPosition = new SunVector(0, 0, 0);
            DestinationPosition = new SunVector(0, 0, 0);
        }

        public SkillResultPosition(SkillResultAbility baseInfo) : base(baseInfo)
        {
            CurrentPosition = new SunVector(0, 0, 0);
            DestinationPosition = new SunVector(0, 0, 0);
        }

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

        public SkillResultExhaust(SkillResultAbility baseInfo) :base(baseInfo) { }

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
