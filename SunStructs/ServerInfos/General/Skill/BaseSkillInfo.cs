using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using CDShared.Logging;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General.Object.Items;
using static SunStructs.Definitions.AbilityID;
using static SunStructs.Definitions.AbilityRangeType;
using static SunStructs.Definitions.ArmorType;
using static SunStructs.Definitions.AttackType;
using static SunStructs.Definitions.AttrType;
using static SunStructs.Definitions.AttrValueKind;
using static SunStructs.Definitions.StatType;

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
        public readonly int CSSyncDelay;
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
        public readonly byte TargetType;
        public readonly byte ForbiddenTarget;
        public readonly float HPCost;
        public readonly float MPCost;
        public readonly ushort SkillCasting;
        public readonly uint Cooldown;
        public readonly ushort SkillRange;
        public readonly byte AttackRangeForm;
        public readonly ushort SkillArea;
        public readonly ushort ChaseRange;
        public readonly byte MaxTargetNum;
        public readonly byte SkillAcquire;
        public readonly BaseAbilityInfo[] BaseAbilityInfos;

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
            CSSyncDelay = int.Parse(info[16]);
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
            TargetType = byte.Parse(info[39]);
            ForbiddenTarget = byte.Parse(info[40]);
            HPCost = float.Parse(info[41]);
            MPCost = float.Parse(info[42]);
            SkillCasting = ushort.Parse(info[43]);
            Cooldown = uint.Parse(info[44]);
            SkillRange= ushort.Parse(info[45]);
            AttackRangeForm = byte.Parse(info[46]);
            SkillArea = ushort.Parse(info[47]);
            ChaseRange= ushort.Parse(info[48]);
            MaxTargetNum = byte.Parse(info[49]);
            BaseAbilityInfos = new[]
            {
                new BaseAbilityInfo(0,info, 51),
                new BaseAbilityInfo(1,info, 61),
                new BaseAbilityInfo(2,info, 71),
                new BaseAbilityInfo(3,info, 81),
                new BaseAbilityInfo(4,info, 91),
            };
            SkillAcquire = byte.Parse(info[101]);

        }
        public bool IsNonStopSkill()
        {
            return WZAnimCode == "NULL";
        }



        public bool TryGetAbilityInfo(AbilityID id,out BaseAbilityInfo? info)
        {
            info = null;
            foreach (var baseAbilityInfo in BaseAbilityInfos)
            {
                if (baseAbilityInfo.AbilityId == id)
                {
                    info = baseAbilityInfo;
                    return true;
                }
            }

            return false;
        }

        public BaseAbilityInfo? GetAbilityInfoByIndex(int index)
        {
            try
            {
                return BaseAbilityInfos[index];
            }
            catch (IndexOutOfRangeException e)
            {
                Logger.Instance.Log(e);
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
    public class IffFilter
    {
        internal enum IffCheck
        {
            IFF_NONE = 0,
            //
            IFF_CHECK_SKIP = 1 << 0,
            //
            IFF_ONE = 1 << 3,
            IFF_PLAYER = 1 << 4,

            IFF_CORPSE = 1 << 7,
            IFF_RESURRECTION = 1 << 8,
            //
            IFF_ENEMY = 1 << 11,
            IFF_FRIEND = 1 << 12,
            //
            IFF_ATTACKER_ONLY = 1 << 18,
            IFF_MAIN_TARGET_ONLY = 1 << 19,
            //
        }
        internal enum IffAbilityCondition
        {
            IFF_ABILITY_CONDITION_ACTOR_ONLY
                = (1 << SKILL_ABILITY_ME),

            IFF_ABILITY_CONDITION_MAIN_TARGET_ONLY
                = (1 << SKILL_ABILITY_FRIEND)
                  | (1 << SKILL_ABILITY_ENEMY),

            IFF_ABILITY_CONDITION_CORPSE_ABILITIES
                = (1 << SKILL_ABILITY_CORPSE_RESURRECTION)
                  | (1 << SKILL_ABILITY_CORPSE_FRIEND)
                  | (1 << SKILL_ABILITY_MYAREA_CORPSE_ENEMY)
                  | (1 << SKILL_ABILITY_CORPSE_ENEMY),

            IFF_ABILITY_CONDITION_ENABLED_RESURRECTION
                = (1 << SKILL_ABILITY_CORPSE_RESURRECTION),

            IFF_ABILITY_CONDITION_PLAYER
                = (1 << SKILL_ABILITY_PLAYER_ENEMY),

            IFF_ABILITY_CONDITION_SKIP_ABILITIES
                = (1 << SKILL_ABILITY_FIELD)
                  | (1 << SKILL_ABILITY_SUMMON)
                  | (1 << SKILL_ABILITY_SUMMONED_MONSTER),

            IFF_ABILITY_CONDITION_FRIEND_ABILITIES
                = (1 << SKILL_ABILITY_FRIEND)
                  | (1 << SKILL_ABILITY_TARGETAREA_FRIEND)
                  | (1 << SKILL_ABILITY_MYAREA_FRIEND)
                  | (1 << SKILL_ABILITY_CORPSE_FRIEND),

            IFF_ABILITY_CONDITION_ENEMY_ABILITIES
                = (1 << SKILL_ABILITY_ENEMY)
                  | (1 << SKILL_ABILITY_TARGETAREA_ENEMY)
                  | (1 << SKILL_ABILITY_MYAREA_ENEMY)
                  | (1 << SKILL_ABILITY_MYAREA_CORPSE_ENEMY)
                  | (1 << SKILL_ABILITY_CORPSE_ENEMY),
        };

        public ulong ValueType;
        public bool IsValidated;

        public IffFilter(BaseAbilityInfo info)
        {
            var rangeType = (AbilityRangeType) info.RangeType;
            if (info.AbilityId != 0 &&
                rangeType != SKILL_ABILITY_NONE &&
                rangeType < SKILL_ABILITY_MAX)
            {
                IsValidated = false;
            }

            ulong rangeTypeBit = (ulong) (1 << (int) rangeType);
            ulong selectFilter = 0;
            if((rangeTypeBit & (int)IffAbilityCondition.IFF_ABILITY_CONDITION_ACTOR_ONLY) != 0) selectFilter |= (ulong)IffCheck.IFF_ATTACKER_ONLY;
            if((rangeTypeBit & (int)IffAbilityCondition.IFF_ABILITY_CONDITION_MAIN_TARGET_ONLY) != 0) selectFilter |= (ulong)IffCheck.IFF_ATTACKER_ONLY | (ulong)IffCheck.IFF_MAIN_TARGET_ONLY;
            if ((rangeTypeBit & (int)IffAbilityCondition.IFF_ABILITY_CONDITION_CORPSE_ABILITIES) != 0) selectFilter |= (ulong)IffCheck.IFF_CORPSE;
            if ((rangeTypeBit & (int)IffAbilityCondition.IFF_ABILITY_CONDITION_ENABLED_RESURRECTION) != 0) selectFilter |= (ulong)IffCheck.IFF_RESURRECTION;
            if ((rangeTypeBit & (int)IffAbilityCondition.IFF_ABILITY_CONDITION_PLAYER) != 0) selectFilter |= (ulong)IffCheck.IFF_PLAYER;
            if ((rangeTypeBit & (int)IffAbilityCondition.IFF_ABILITY_CONDITION_SKIP_ABILITIES) != 0) selectFilter |= (ulong)IffCheck.IFF_CHECK_SKIP;
            if ((rangeTypeBit & (int)IffAbilityCondition.IFF_ABILITY_CONDITION_FRIEND_ABILITIES) != 0) selectFilter |= (ulong)IffCheck.IFF_FRIEND;
            if ((rangeTypeBit & (int)IffAbilityCondition.IFF_ABILITY_CONDITION_ENEMY_ABILITIES) != 0) selectFilter |= (ulong)IffCheck.IFF_ENEMY;

            ValueType = selectFilter;
            IsValidated = true;
        }
    }
    public class BaseAbilityInfo
    {
        public int Index;
        public AbilityID AbilityId;
        public IffFilter Filter;
        public AbilityRangeType RangeType;
        public int SuccessRate;
        public int option1;
        public int option2;
        public int[] Params;
        public CharStateType CharStateType;
        public AttrType Attribute;
        public BaseAbilityInfo(){}
        public BaseAbilityInfo EditableCopy()
        {
            var result = new BaseAbilityInfo()
            {
                Index = this.Index,
                AbilityId = this.AbilityId,
                RangeType = RangeType,
                SuccessRate = SuccessRate,
                option1 = option1,
                option2 = option2,
                Params = new int[]
                {
                    Params[0],
                    Params[1],
                    Params[2],
                    Params[3]
                },
                CharStateType = CharStateType,
                Attribute = Attribute
            };
            result.Filter = new IffFilter(result);

            return result;
        }
        public BaseAbilityInfo(int index, string[] info, int startIndex)
        {
            Index = index;
            AbilityId = (AbilityID)ushort.Parse(info[startIndex]);
            RangeType = (AbilityRangeType) int.Parse(info[startIndex + 1]);
            SuccessRate = int.Parse(info[startIndex + 2]) * 10;
            option1 = int.Parse(info[startIndex + 3]);
            option2 = int.Parse(info[startIndex + 4]);

            Params = new[]
            {
                int.Parse(info[startIndex + 5]),
                int.Parse(info[startIndex + 6]),
                int.Parse(info[startIndex + 7]),
                int.Parse(info[startIndex + 8]),
                //int.Parse(info[startIndex + 9])//charStateType
            };
            CharStateType = (CharStateType) int.Parse(info[startIndex + 9]);
            Attribute = GetAttrType();
            Filter = new IffFilter(this);
        }

        private AttrType GetAttrType()
        {
            switch (AbilityId)
            {
                case ABILITY_MAX_HP_INCREASE: return ATTR_MAX_HP;
                case ABILITY_CUR_HP_INCREASE: return ATTR_CUR_HP;
                case ABILITY_RECOVER_HP_INCREASE: return ATTR_RECOVERY_HP;

                case ABILITY_MAX_MP_INCREASE: return ATTR_MAX_MP;
                case ABILITY_CUR_MP_INCREASE: return ATTR_CUR_MP;
                case ABILITY_RECOVER_MP_INCREASE: return ATTR_RECOVERY_MP;

                case ABILITY_PHYSICAL_ATTACKPOWER_INCREASE:
                case ABILITY_MAGIC_ATTACKPOWER_INCREASE: return GetAttrTypeForAttackPower((AttackType)option1);
                case ABILITY_ATTACKPOWER_BY_ARMORTYPE: return GetAttrTypeForBonusDamage((ArmorType)option1, (uint)Params[0]);

                case ABILITY_PHYSICAL_DEFENSE_INCREASE:
                case ABILITY_MAGIC_DEFENSE_INCREASE: return GetAttrTypeForDefense((AttackType)option1);
                case ABILITY_DEFENSE_BY_ATTACKTYPE: return GetAttrTypeForBonusDefense((AttackType)option1);

                case ABILITY_STAT_INCREASE: return GetAttrTypeForStat((StatType)option1);

                case ABILITY_PHYSICAL_ATTACKRATE_INCREASE: return ATTR_PHYSICAL_ATTACK_SUCCESS_RATIO;
                case ABILITY_PHYSICAL_AVOIDRATE_INCREASE: return ATTR_PHYSICAL_ATTACK_BLOCK_RATIO;

                case ABILITY_MOVE_SPEED_INCREASE:
                case ABILITY_HIDE:
                    return ATTR_MOVE_SPEED;
                case ABILITY_PHYSICAL_SPEED_INCREASE: return ATTR_ATTACK_SPEED;
                case ABILITY_CASTING_TIME_INCREASE: return ATTR_BONUS_CASTING_TIME;

                case ABILITY_DAMAGE_DECREASE: return GetAttrTypeForReduceDamage((AttackType)option1);

                case ABILITY_SKILLRANGE_INCREASE: return ATTR_SKILL_ATTACK_RANGE;

                case ABILITY_CRITICAL_RATIO_CHANGE: return ATTR_ADD_ALL_CRITICAL_RATIO;
                case ABILITY_CRITICAL_DAMAGE_CHANGE: return ATTR_CRITICAL_DAMAGE_CHANGE;

                case ABILITY_LOWHP_ATTACKPOWER_CHANGE: return GetAttrTypeForAttackPower((AttackType)option1);
                case ABILITY_LOWHP_DEFENSE_CHANGE: return GetAttrTypeForDefense((AttackType)option1);

                case ABILITY_SKILL_COOL_TIME_INCREASE: return ATTR_BONUS_SKILL_COOL_TIME;
                case ABILITY_MP_SPEND_INCREASE: return ATTR_MP_SPEND_INCREASE;
                case ABILITY_SKILLDAMAGE_INCREASE: return ATTR_ADD_SKILL_DAMAGE_RATIO;

                case ABILITY_ATTR_ATTACK_POWER: return GetAttrTypeForAttackPower((AttackType)option1);
                case ABILITY_ATTR_DEFENSIVE_POWER: return GetAttrTypeForDefense((AttackType) option1);

                case ABILITY_CHANGE_ATTR: return GlobalItemOption.GetItemAttrOption(Params[0]);

                case ABILITY_RECOVERY_CHANCE: return ATTR_INCREASE_RESERVE_HP;
                case ABILITY_RESIST_HOLDING: return ATTR_RESIST_HOLDING;
                case ABILITY_RESIST_SLEEP: return ATTR_RESIST_SLEEP;
                case ABILITY_RESIST_POISON: return ATTR_RESIST_POISON;
                case ABILITY_RESIST_KNOCKBACK: return ATTR_RESIST_KNOCKBACK;
                case ABILITY_RESIST_DOWN: return ATTR_RESIST_DOWN;
                case ABILITY_RESIST_STUN: return ATTR_RESIST_STUN;
                case ABILITY_DECREASE_PVPDAMAGE: return ATTR_DECREASE_PVPDAMAGE;
                case ABILITY_SKILL_STATE_IGNORE: return ATTR_RESISTANCE_BADSTATUS_RATIO;

                case ABILITY_MAX_SD_INCREASE: return ATTR_MAX_SD;
                case ABILITY_RECOVER_SD_INCREASE: return ATTR_RECOVERY_SD;
                case ABILITY_CUR_SD_INCREASE: return ATTR_CUR_SD;

                case ABILITY_INCREASE_DAMAGE: return ATTR_INCREASE_DAMAGE_RATIO;

                default: return ATTR_TYPE_INVALID;
            }
        }

        public AttrType GetAttrTypeForAttackPower(AttackType attackType)
        {
            return attackType switch
            {
                ATTACK_TYPE_ALL_OPTION => ATTR_OPTION_ALL_ATTACK_POWER,
                ATTACK_TYPE_MELEE => ATTR_BASE_MELEE_MIN_ATTACK_POWER,
                ATTACK_TYPE_RANGE => ATTR_BASE_RANGE_MIN_ATTACK_POWER,
                ATTACK_TYPE_WATER => ATTR_MAGICAL_WATER_ATTACK_POWER,
                ATTACK_TYPE_FIRE => ATTR_MAGICAL_FIRE_ATTACK_POWER,
                ATTACK_TYPE_WIND => ATTR_MAGICAL_WIND_ATTACK_POWER,
                ATTACK_TYPE_EARTH => ATTR_MAGICAL_EARTH_ATTACK_POWER,
                ATTACK_TYPE_DARKNESS => ATTR_MAGICAL_DARKNESS_ATTACK_POWER,
                ATTACK_TYPE_DIVINE => ATTR_MAGICAL_DIVINE_ATTACK_POWER,
                ATTACK_TYPE_PHYSICAL_OPTION => ATTR_OPTION_PHYSICAL_ATTACK_POWER,
                ATTACK_TYPE_MAGIC_OPTION => ATTR_OPTION_MAGICAL_ATTACK_POWER,
                ATTACK_TYPE_ALL_MAGIC => ATTR_MAGICAL_ALL_ATTACK_POWER,
                _ => ATTR_BASE_MELEE_MIN_ATTACK_POWER
            };
        }

        public AttrType GetAttrTypeForBonusDamage(ArmorType armorType, uint valueType)
        {
            if (valueType == (uint)VALUE_TYPE_VALUE)
            {
                switch (armorType)
                {
                    case ARMOR_HARD: return ATTR_ADD_ARMOR_HARD_DAMAGE;
                    case ARMOR_MEDIUM: return ATTR_ADD_ARMOR_MEDIUM_DAMAGE;
                    case ARMOR_SOFT: return ATTR_ADD_ARMOR_SOFT_DAMAGE;
                    case ARMOR_SIEGE: return ATTR_ADD_ARMOR_SIEGE_DAMAGE;
                    case ARMOR_UNARMOR: return ATTR_ADD_ARMOR_UNARMOR_DAMAGE;
                    default: return ATTR_ADD_ARMOR_HARD_DAMAGE;
                }
            }
            else if (valueType == (int)VALUE_TYPE_RATIO_VALUE)
            {
                switch (armorType)
                {
                    case ARMOR_HARD: return ATTR_ADD_RATIO_ARMOR_HARD_DAMAGE;
                    case ARMOR_MEDIUM: return ATTR_ADD_RATIO_ARMOR_MEDIUM_DAMAGE;
                    case ARMOR_SOFT: return ATTR_ADD_RATIO_ARMOR_SOFT_DAMAGE;
                    case ARMOR_SIEGE: return ATTR_ADD_RATIO_ARMOR_SIEGE_DAMAGE;
                    case ARMOR_UNARMOR: return ATTR_ADD_RATIO_ARMOR_UNARMOR_DAMAGE;
                    default: return ATTR_ADD_RATIO_ARMOR_HARD_DAMAGE;
                }
            }
            else
            {
                Logger.Instance.Log("BASE_ABILITYINFO : [GetAttrTypeForBonusDamage] Invalid ValueType " + valueType + "! \n");
                return ATTR_ADD_ARMOR_HARD_DAMAGE;
            }
        }

        public AttrType GetAttrTypeForDefense(AttackType attackType)
        {
            switch (attackType)
            {
                case ATTACK_TYPE_ALL_OPTION: return ATTR_OPTION_ALL_DEFENSE_POWER;
                case ATTACK_TYPE_MELEE: return ATTR_BASE_MELEE_DEFENSE_POWER;
                case ATTACK_TYPE_RANGE: return ATTR_BASE_RANGE_DEFENSE_POWER;
                case ATTACK_TYPE_WATER: return ATTR_MAGICAL_WATER_DEFENSE_POWER;
                case ATTACK_TYPE_FIRE: return ATTR_MAGICAL_FIRE_DEFENSE_POWER;
                case ATTACK_TYPE_WIND: return ATTR_MAGICAL_WIND_DEFENSE_POWER;
                case ATTACK_TYPE_EARTH: return ATTR_MAGICAL_EARTH_DEFENSE_POWER;
                case ATTACK_TYPE_DARKNESS: return ATTR_MAGICAL_DARKNESS_DEFENSE_POWER;
                case ATTACK_TYPE_DIVINE: return ATTR_MAGICAL_DIVINE_DEFENSE_POWER;
                case ATTACK_TYPE_PHYSICAL_OPTION: return ATTR_OPTION_PHYSICAL_DEFENSE_POWER;
                case ATTACK_TYPE_MAGIC_OPTION: return ATTR_OPTION_MAGICAL_DEFENSE_POWER;
                case ATTACK_TYPE_ALL_MAGIC: return ATTR_MAGICAL_ALL_DEFENSE_POWER;
                default:
                    return ATTR_BASE_MELEE_DEFENSE_POWER;
            }
        }
        public AttrType GetAttrTypeForBonusDefense(AttackType attackType)
        {
            switch (attackType)
            {
                case ATTACK_TYPE_ALL_OPTION: return ATTR_ADD_ALL_DEFENSE_POWER;
                case ATTACK_TYPE_MELEE: return ATTR_ADD_MELEE_DEFENSE_POWER;
                case ATTACK_TYPE_RANGE: return ATTR_ADD_RANGE_DEFENSE_POWER;
                case ATTACK_TYPE_WATER: return ATTR_ADD_WATER_DEFENSE_POWER;
                case ATTACK_TYPE_FIRE: return ATTR_ADD_FIRE_DEFENSE_POWER;
                case ATTACK_TYPE_WIND: return ATTR_ADD_WIND_DEFENSE_POWER;
                case ATTACK_TYPE_EARTH: return ATTR_ADD_EARTH_DEFENSE_POWER;
                case ATTACK_TYPE_DARKNESS: return ATTR_ADD_DARKNESS_DEFENSE_POWER;
                case ATTACK_TYPE_DIVINE: return ATTR_ADD_DIVINE_DEFENSE_POWER;
                case ATTACK_TYPE_PHYSICAL_OPTION: return ATTR_ADD_PHYSICAL_DEFENSE_POWER;
                case ATTACK_TYPE_MAGIC_OPTION: return ATTR_ADD_MAGICAL_DEFENSE_POWER;
                case ATTACK_TYPE_ALL_MAGIC: return ATTR_ADD_MAGICAL_ALL_DEFENSE_POWER;
                default:
                    return ATTR_ADD_MELEE_DEFENSE_POWER;
            }
        }
        public AttrType GetAttrTypeForStat(StatType statType)
        {
            switch (statType)
            {
                case STAT_TYPE_STR: return ATTR_STR;
                case STAT_TYPE_DEX: return ATTR_DEX;
                case STAT_TYPE_VIT: return ATTR_VIT;
                case STAT_TYPE_SPR: return ATTR_SPR;
                case STAT_TYPE_INT: return ATTR_INT;
                default:
                    return ATTR_STR;
            }
        }
        public AttrType GetAttrTypeForReduceDamage(AttackType attackType)
        {
            switch (attackType)
            {
                case ATTACK_TYPE_ALL_OPTION: return ATTR_DEL_ALL_DAMAGE;
                case ATTACK_TYPE_MELEE: return ATTR_DEL_MELEE_DAMAGE;
                case ATTACK_TYPE_RANGE: return ATTR_DEL_RANGE_DAMAGE;
                case ATTACK_TYPE_WATER: return ATTR_DEL_WATER_DAMAGE;
                case ATTACK_TYPE_FIRE: return ATTR_DEL_FIRE_DAMAGE;
                case ATTACK_TYPE_WIND: return ATTR_DEL_WIND_DAMAGE;
                case ATTACK_TYPE_EARTH: return ATTR_DEL_EARTH_DAMAGE;
                case ATTACK_TYPE_DARKNESS: return ATTR_DEL_DARKNESS_DAMAGE;
                case ATTACK_TYPE_DIVINE: return ATTR_DEL_DIVINE_DAMAGE;
                case ATTACK_TYPE_PHYSICAL_OPTION: return ATTR_DEL_PHYSICAL_DAMAGE;
                case ATTACK_TYPE_MAGIC_OPTION: return ATTR_DEL_MAGICAL_DAMAGE;
                case ATTACK_TYPE_ALL_MAGIC: return ATTR_DEL_MAGICAL_ALL_DAMAGE;
                default:
                    return ATTR_DEL_MELEE_DAMAGE;
            }
        }


    }

}