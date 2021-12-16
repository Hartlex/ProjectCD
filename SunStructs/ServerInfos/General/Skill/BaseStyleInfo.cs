using CDShared.Parsing;

namespace SunStructs.ServerInfos.General.Skill
{
    public class BaseStyleInfo : RootSkillInfo
    {
        public readonly string Name;
        public readonly ushort StyleNameCode;
        public readonly ushort StyleDescCode;
        public readonly ushort SkillAttribute;
        public readonly uint StyleImage;
        public readonly ushort RequireLevel;
        public readonly ushort StyleLevel;
        public readonly ushort MaxLevel;
        public readonly ushort OverLevel;
        public readonly ushort[] OverStatClass;
        public readonly ushort[] OverStat;
        public readonly byte RequireSkillPoint;
        public readonly byte ClassDefine;
        public readonly int WeaponDefine;
        public readonly byte AttType;
        public readonly float AttRange;
        public readonly byte MoveAttack;
        public readonly byte StyleCheck;
        public readonly ushort TimeFirst;
        public readonly ushort TimeSecond;
        public readonly ushort TimeThird;
        public readonly int[] AddDamage;
        public readonly float[] DamagePercent;
        public readonly byte AttRangeForm;
        public readonly float StyleArea;
        public readonly float ThirdDelay;
        public readonly int AttackRate;
        public readonly int AvoidRate;
        public readonly int AttackSpeed;
        public readonly int BonusDefense;
        public readonly int MagicDefense;
        public readonly ushort CriticalBonus;
        public readonly float DefenseIgnore;
        public readonly float PierceRate;
        public readonly float PierceRange;
        public readonly float StunRate;
        public readonly ushort StunTime;
        public readonly float KnockBackRate;
        public readonly float KnockBackRange;
        public readonly float DownRate;
        public readonly float DelayReduce;
        public readonly float DelayOccur;
        public readonly ushort HPAbsorb;
        public readonly float HPAbsorbPer;
        public readonly ushort MPAbsorb;
        public readonly float MPAbsorbPer;
        public readonly ushort MaxTargetNum;

        public BaseStyleInfo(string[] infos) : base(
            ushort.Parse(infos[0]),
            ushort.Parse(infos[1]),
            RootSkillType.STYLE)
        {
            var sb = new StringBuffer(infos);
            sb.Skip(2);
            Name = sb.ReadString();
            StyleNameCode = sb.ReadUshort();
            StyleDescCode = sb.ReadUshort();
            SkillAttribute = sb.ReadUshort();
            StyleImage = sb.ReadUint();
            RequireLevel = sb.ReadUshort();
            StyleLevel = sb.ReadUshort();
            MaxLevel = sb.ReadUshort();
            OverLevel = sb.ReadUshort();
            OverStatClass = new ushort[2];
            OverStat = new ushort[2];
            OverStatClass[0] = sb.ReadUshort();
            OverStat[0] = sb.ReadUshort();           
            OverStatClass[1] = sb.ReadUshort();
            OverStat[1] = sb.ReadUshort();
            RequireSkillPoint = sb.ReadByte();
            ClassDefine = sb.ReadByte();
            WeaponDefine = sb.ReadInt();
            AttType = sb.ReadByte();
            AttRange = sb.ReadFloat();
            MoveAttack = sb.ReadByte();
            StyleCheck = sb.ReadByte();
            sb.Skip(4);
            TimeFirst = sb.ReadUshort();
            TimeSecond = sb.ReadUshort();
            TimeThird = sb.ReadUshort();
            AddDamage = new int[3];
            DamagePercent = new float[3];
            AddDamage[0] = sb.ReadInt();
            DamagePercent[0] = sb.ReadFloat();
            AddDamage[1] = sb.ReadInt();
            DamagePercent[1] = sb.ReadFloat();
            AddDamage[2] = sb.ReadInt();
            DamagePercent[2] = sb.ReadFloat();
            AttRangeForm = sb.ReadByte();
            StyleArea = sb.ReadFloat();
            ThirdDelay = sb.ReadFloat();
            AttackRate = sb.ReadInt();
            AvoidRate = sb.ReadInt();
            AttackSpeed = sb.ReadInt();
            BonusDefense = sb.ReadInt();
            MagicDefense = sb.ReadInt();
            CriticalBonus = sb.ReadUshort();
            DefenseIgnore = sb.ReadFloat();
            PierceRate = sb.ReadFloat();
            PierceRange = sb.ReadFloat();
            StunRate = sb.ReadFloat();
            StunTime = sb.ReadUshort();
            KnockBackRate = sb.ReadFloat();
            KnockBackRange = sb.ReadFloat();
            DownRate = sb.ReadFloat();
            DelayReduce = sb.ReadFloat();
            DelayOccur = sb.ReadFloat();
            HPAbsorb = sb.ReadUshort();
            HPAbsorbPer = sb.ReadFloat();
            MPAbsorb = sb.ReadUshort();
            MPAbsorbPer = sb.ReadFloat();
            MaxTargetNum = sb.ReadUshort();

        }

        public override bool IsMaxLevel()
        {
            return StyleLevel == MaxLevel;
        }

        public override byte GetSkillPointCost()
        {
            return RequireSkillPoint;
        }
    }
}
