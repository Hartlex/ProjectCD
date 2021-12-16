using CDShared.Logging;
using SunStructs.Definitions;
using static SunStructs.Definitions.AbilityType;
using static SunStructs.Definitions.AttrType;

namespace SunStructs.ServerInfos.General.Skill
{
    public class BaseSkillInfo : RootSkillInfo
    {
        public readonly string SkillName;
        public readonly ushort NameCode1;
        public readonly ushort SkillDescCode;
        public readonly ushort SkillIconCode;
        public readonly int[] WeaponDefine;
        public readonly string WZAnimCode;
        public readonly uint CastAnimCode;
        public readonly ushort FlyingObjCode;
        public readonly ushort FlyingLifeTime;
        public readonly uint FieldEffectCode;
        public readonly ushort SkillAttribute;
        public readonly ushort RequireLevel;
        public readonly ushort SkillLevel;
        public readonly ushort MaxLvl;
        public readonly ushort OverLvl;
        public readonly SkillOverStat[] OverStats;
        public readonly SkillType SkillType;
        public readonly byte SkillUserType;
        public readonly ushort ClassDefine;
        public readonly byte SkillStatType;
        public readonly ushort[] RequireSkillStat;
        public readonly byte RequireSkillPoint;
        public readonly byte Target;
        public readonly byte ForbiddenTarget;
        public readonly ushort HPCost;
        public readonly ushort MPCost;
        public readonly ushort SkillCasting;
        public readonly uint Cooldown;
        public readonly ushort SkillRange;
        public readonly byte AttackRangeForm;
        public readonly ushort SkillArea;
        public readonly ushort ChaseRange;
        public readonly byte MaxTargetNum;
        public readonly byte SkillAcquire;
        public readonly BaseAbilityInfo[] BaseAbilityInfos;
        
        private readonly Dictionary<AbilityType,BaseAbilityInfo> _abilityInfos = new();
        private readonly List<BaseAbilityInfo> _abilityInfoList = new();
        
        public BaseSkillInfo(string[] info) : base(
            ushort.Parse(info[1]),
            ushort.Parse(info[2]),
            RootSkillType.SKILL)
        {
            SkillName = info[3];
            NameCode1 = ushort.Parse(info[4]);
            SkillDescCode = ushort.Parse(info[5]);
            SkillIconCode = ushort.Parse(info[6]);
            WeaponDefine = new int[4];
            WeaponDefine[0] = int.Parse(info[8]);
            WeaponDefine[1] = int.Parse(info[10]);
            WeaponDefine[2] = int.Parse(info[12]);
            WeaponDefine[3] = int.Parse(info[14]);
            WZAnimCode = info[9];
            FlyingObjCode = ushort.Parse(info[18]);
            FlyingLifeTime= ushort.Parse(info[19]);
            FieldEffectCode = uint.Parse(info[21]);
            SkillAttribute = ushort.Parse(info[22]);
            RequireLevel = ushort.Parse(info[23]);
            SkillLevel= ushort.Parse(info[24]);
            MaxLvl = ushort.Parse(info[25]);
            OverLvl= ushort.Parse(info[26]);
            OverStats = new[]
            {
                new SkillOverStat(ushort.Parse(info[27]), ushort.Parse(info[28])),
                new SkillOverStat(ushort.Parse(info[29]), ushort.Parse(info[30]))
            };
            SkillType = (SkillType) byte.Parse(info[31]);
            SkillUserType = byte.Parse(info[33]);
            ClassDefine = ushort.Parse(info[34]);
            SkillStatType = byte.Parse(info[35]);
            RequireSkillStat = new[] {ushort.Parse(info[36]), ushort.Parse(info[37])};
            RequireSkillPoint = byte.Parse(info[38]);
            Target = byte.Parse(info[39]);
            ForbiddenTarget = byte.Parse(info[40]);
            HPCost = ushort.Parse(info[41]);
            MPCost = ushort.Parse(info[42]);
            SkillCasting = ushort.Parse(info[43]);
            Cooldown = uint.Parse(info[44]);
            SkillRange= ushort.Parse(info[45]);
            AttackRangeForm = byte.Parse(info[46]);
            SkillArea = ushort.Parse(info[47]);
            ChaseRange= ushort.Parse(info[48]);
            MaxTargetNum = byte.Parse(info[49]);
            BaseAbilityInfos = new[]
            {
                new BaseAbilityInfo(info, 51),
                new BaseAbilityInfo(info, 61),
                new BaseAbilityInfo(info, 71),
                new BaseAbilityInfo(info, 81),
                new BaseAbilityInfo(info, 91),
            };
            SkillAcquire = byte.Parse(info[101]);
        }
        public bool IsNonStopSkill()
        {
            return WZAnimCode == "NULL";
        }
        public void AddAbility(BaseAbilityInfo abilityInfo)
        {
            _abilityInfos.Add(abilityInfo.AbilityId,abilityInfo);
            _abilityInfoList.Add(abilityInfo);
        }

        public BaseAbilityInfo GetAbilityInfo(AbilityType abilityCode)
        {
            if (_abilityInfos.ContainsKey(abilityCode))
                return _abilityInfos[abilityCode];
            return null;
        }

        public BaseAbilityInfo GetAbilityInfo(byte index)
        {
            try
            {
                return _abilityInfoList[index];
            }
            catch (KeyNotFoundException e)
            {
                Logger.Instance.Log("Ability not found",LogType.ERROR);
                return null;
            }
        }
        public override bool IsMaxLevel()
        {
            return SkillLevel == MaxLvl;
        }

        public override byte GetSkillPointCost()
        {
            return RequireSkillPoint;
        }
    }

    public class SkillOverStat
    {
        public readonly ushort StatClass;
        public readonly ushort Stat;

        public SkillOverStat(ushort statClass, ushort stat)
        {
            StatClass = statClass;
            Stat = stat;
        }
    }

    public class BaseAbilityInfo
    {
        public readonly AbilityType AbilityId;
        public readonly byte RangeType;
        public readonly ushort SuccessRate;
        public readonly uint option1;
        public readonly uint option2;
        public readonly ushort StateId;
        public readonly int[] Params;

        public BaseAbilityInfo(string[] info, int startIndex)
        {
            AbilityId = (AbilityType)ushort.Parse(info[startIndex]);
            RangeType = byte.Parse(info[startIndex + 1]);
            SuccessRate = ushort.Parse(info[startIndex + 2]);
            option1 = uint.Parse(info[startIndex + 3]);
            option2 = uint.Parse(info[startIndex + 4]);

            Params = new[]
            {
                int.Parse(info[startIndex + 5]),
                int.Parse(info[startIndex + 6]),
                int.Parse(info[startIndex + 7]),
                int.Parse(info[startIndex + 8]),
                int.Parse(info[startIndex + 9])
            };
            StateId = (ushort) Params[4];
        }

        public AttrType GetAttrType()
        {
            return ATTR_TYPE_INVALID;
        }

    }

}