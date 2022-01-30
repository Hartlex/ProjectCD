using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using ProjectCD.Objects.Game.CDObject.CDCharacter;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState;
using SunStructs.Definitions;
using SunStructs.Formulas.Char;
using SunStructs.PacketInfos.Game.Status.Server;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Skill;
using static SunStructs.Definitions.AttackType;
using static SunStructs.Definitions.AttrType;
using static SunStructs.Definitions.UserRelationType;

namespace ProjectCD.Formulas
{
    internal static class CharacterFormulas
    {
        private static readonly Dictionary<MeleeType, Dictionary<ArmorType, float>> _weaponArmorMap = new()
        {
            {MeleeType.MELEE_TYPE_SLASH, new()
                {
                    {ArmorType.ARMOR_HARD, 100},
                    {ArmorType.ARMOR_MEDIUM, 80},
                    {ArmorType.ARMOR_SOFT, 120},
                    {ArmorType.ARMOR_SIEGE, 50},
                    {ArmorType.ARMOR_UNARMOR, 120}
                }
            },
            {MeleeType.MELEE_TYPE_PIERCE,
                new()
                {
                    { ArmorType.ARMOR_HARD, 100 },
                    { ArmorType.ARMOR_MEDIUM, 120 },
                    { ArmorType.ARMOR_SOFT, 100 },
                    { ArmorType.ARMOR_SIEGE, 50 },
                    { ArmorType.ARMOR_UNARMOR, 120 }
                }
            },
            {MeleeType.MELEE_TYPE_HIT,
                new()
                {
                    { ArmorType.ARMOR_HARD, 80 },
                    { ArmorType.ARMOR_MEDIUM, 100 },
                    { ArmorType.ARMOR_SOFT, 80 },
                    { ArmorType.ARMOR_SIEGE, 150 },
                    { ArmorType.ARMOR_UNARMOR, 120 }
                }
            },
            {MeleeType.MELEE_TYPE_MAGIC,
                new()
                {
                    { ArmorType.ARMOR_HARD, 120 },
                    { ArmorType.ARMOR_MEDIUM, 80 },
                    { ArmorType.ARMOR_SOFT, 80 },
                    { ArmorType.ARMOR_SIEGE, 50 },
                    { ArmorType.ARMOR_UNARMOR, 120 }
                }
            },

        };

        internal static bool IsStatusHit(Character attacker, Character target, int successRatio, ushort stateID, SkillBase skill)
        {
            if (attacker.IsFriend(target) == USER_RELATION_FRIEND) return true;

            float calcRatio = successRatio;

            if (attacker.IsObjectType(ObjectType.PLAYER_OBJECT) && target.IsObjectType(ObjectType.PLAYER_OBJECT))
                calcRatio /= 10;
            else
            {
                float gradeRatio = 1.0f;
                if (target is NPC npc)
                {
                    gradeRatio = NumericValues.GetStatusRatioAsNPCGrade(npc.GetGrade());
                }

                calcRatio = successRatio * gradeRatio ;
            }

            StateInfoDB.Instance.TryGetStateInfo((CharStateType) stateID,out var stateInfo);
            if (stateInfo.Type is StateType.STATE_TYPE_STRENGTHENING or StateType.STATE_TYPE_SPECIALITY)
            {
                calcRatio = 10000;
            }
            else
            {
                calcRatio -= target.GetResistBadStatusRatio(stateID);
            }


            return GlobalRandom.IsSuccess((int)calcRatio);

        }

        private static int _calcDamage(
            bool normalAttack,
            Character attacker,
            Character target,
            AttackType baseAttackType,
            AttackType magicAttackType,
            int skillAttackPower,
            float skillPercentDamage,
            int criticalRatioBonus,
            ref byte effect,
            byte skillStatType,
            float defenseIgnore,
            bool canCrit
        )
        {
            if (normalAttack && !IsPhysicalHit(attacker, target)) return 0;

            int resultDmg = 0;

            int baseDmg = _calcBaseDamage(attacker, target, baseAttackType, skillAttackPower, skillPercentDamage,
                skillStatType, defenseIgnore);

            resultDmg += baseDmg;

            int magicDamage = _calcMagicalDamage(attacker, target, magicAttackType, skillAttackPower,
                skillPercentDamage, skillStatType);

            resultDmg += magicDamage;

            var attackerAttr = attacker.GetAttributes();

            if (canCrit)
            {
                int critRatio = criticalRatioBonus;
                if (baseAttackType is ATTACK_TYPE_MELEE or ATTACK_TYPE_RANGE)
                    critRatio += attackerAttr[ATTR_CRITICAL_RATIO_CHANGE].GetValue();
                else 
                    critRatio += attackerAttr[ATTR_ADD_MAGICAL_CRITICAL_RATIO].GetValue();

                int critDamageBonus = attackerAttr[ATTR_CRITICAL_DAMAGE_CHANGE].GetValue();
                float critDamagePercentBonus = attackerAttr[ATTR_CRITICAL_DAMAGE_CHANGE].GetRatio() / 100;

                int critDamage;
                var status = attacker.GetStatusManager().GetStatusFlag();
                bool needMaxDmg = (status.GetFlags() & (ulong) GeneralStatusFlags.ENABLE_GM_MAX_DAMAGE) != 0;

                critDamage = _calcCriticalDamage(attacker.GetObjectType(), target.GetDisplayLevel(), resultDmg,
                    critRatio, critDamageBonus, critDamagePercentBonus, needMaxDmg);

                if (critDamage != 0)
                {
                    effect |= Const.SKILL_EFFECT_CRITICAL;
                    resultDmg = critDamage;
                }

            }

            int doubleDamage = _calcDoubleDamage(attacker, resultDmg);

            if (doubleDamage != 0)
            {
                effect |= Const.SKILL_EFFECT_DOUBLEDAMAGE;
                resultDmg += doubleDamage;
            }

            resultDmg += attackerAttr[ATTR_ADD_DAMAGE].GetValue();

            return resultDmg;
        }

        private static int _calcDoubleDamage(Character attacker, int resultDmg)
        {
            int doubleDamageRatio = attacker.GetAttributes()[ATTR_DOUBLE_DAMAGE_RATIO].GetValue();
            return GlobalRandom.IsSuccess(doubleDamageRatio * 100) ? resultDmg : 0;
        }

        private static int _calcCriticalDamage(ObjectType objectType, ushort targetLevel, int secondDamage, int critRatio, int critDamageBonus, float critDamagePercentBonus, bool needMaxDmg)
        {
            if (!IsCriticalHit(objectType, critRatio, targetLevel))
                return 0;

            int critDmg = 0;
            if (needMaxDmg)
                critDmg = (int) (secondDamage * 1.2f + secondDamage * 0.5f);
            else
            {
                critDmg = (int)(secondDamage * 1.2f + GlobalRandom.Rand(0,secondDamage) * 0.5f);
            }

            critDmg = (int) (critDmg * (1 + critDamagePercentBonus));
            critDmg += critDamageBonus;

            return critDmg;
        }

        private static int _calcMagicalDamage(Character attacker, Character target, AttackType attackType, int skillAttackPower, float skillPercentDamage, byte skillStatType)
        {
            int baseAttackPower = _calcAttackPower(false, attackType, true, attacker);

            int baseMinAttackPower = 0;
            int baseMaxAttackPower = 0;

            var attackerAttr = attacker.GetAttributes();
            var targetAttr = target.GetAttributes();

            int etherDamageRatio = attackerAttr[ATTR_OPTION_ETHER_DAMAGE_RATIO].GetValue();
            if (etherDamageRatio > 0)
            {
                float tmpRatio = etherDamageRatio / 100f;
                baseMinAttackPower = (int)(baseMinAttackPower * (0.95f + tmpRatio));
                baseMaxAttackPower = (int)(baseMaxAttackPower * (1.05f + tmpRatio));
            }
            else
            {
                baseMinAttackPower = baseMaxAttackPower = baseAttackPower;
            }
            skillPercentDamage += attackerAttr[ATTR_ADD_SKILL_DAMAGE_RATIO].GetValue() / 100;


            int firstMinDamage = _calcFirstDamage(attackType, baseMinAttackPower, 0, 0, skillPercentDamage);
            int firstMaxDamage = _calcFirstDamage(attackType, baseMaxAttackPower, 0, 0, skillPercentDamage);

            int bonusDamage = targetAttr.GetReduceDamage(attackType);
            int targetDefense = _calcDefensePower(false, attackType, attacker, target, 0);

            int secondDamage = 0;

            var status = attacker.GetStatusManager().GetStatusFlag();
            int tmpDamage = firstMinDamage;
            if ((status.GetFlags() & (ulong)GeneralStatusFlags.ENABLE_GM_MAX_DAMAGE) != 0)
                tmpDamage = firstMaxDamage;

            float damamgeDecreaseRatio = 0.7f;

            if (target.IsObjectType(ObjectType.PLAYER_OBJECT) && attacker.IsObjectType(ObjectType.PLAYER_OBJECT))
                damamgeDecreaseRatio = 0.3f;//PVP

            secondDamage = _calcSecondDamage(attackType, tmpDamage, firstMaxDamage, bonusDamage,
                attacker.GetDisplayLevel(), target.GetDisplayLevel(), targetDefense, 1,
                damamgeDecreaseRatio);

            return secondDamage;
        }

        private static int _calcBaseDamage(Character attacker, Character target, AttackType attackType, int skillAttackPower, float skillPercentDamage, byte skillStatType, float defenseIgnore)
        {
            int baseMinAttackPower = _calcAttackPower(true, attackType, true, attacker);
            int baseMaxAttackPower = _calcAttackPower(true, attackType, false, attacker);

            var attackerAttr = attacker.GetAttributes();
            var targetAttr = target.GetAttributes();

            int incBaseMinRatio = attackerAttr[ATTR_INCREASE_MIN_DAMAGE].GetRatio();

            if (incBaseMinRatio > 0)
                baseMinAttackPower -= baseMinAttackPower * incBaseMinRatio/100;
            baseMinAttackPower += attackerAttr[ATTR_INCREASE_MIN_DAMAGE].GetValue();

            int incBaseMaxRatio = attackerAttr[ATTR_INCREASE_MAX_DAMAGE].GetRatio();

            if (incBaseMaxRatio > 0)
                baseMaxAttackPower -= baseMaxAttackPower * incBaseMaxRatio / 100;
            baseMaxAttackPower += attackerAttr[ATTR_INCREASE_MAX_DAMAGE].GetValue();

            int etherDamageRatio = attackerAttr[ATTR_OPTION_ETHER_DAMAGE_RATIO].GetRatio();
            if (etherDamageRatio > 0)
            {
                float tmpRatio = etherDamageRatio / 100f;
                baseMinAttackPower = (int) (baseMinAttackPower * (0.95f + tmpRatio));
                baseMaxAttackPower = (int) (baseMaxAttackPower * (1.05f + tmpRatio));
            }

            skillAttackPower += attackerAttr[ATTR_ADD_SKILL_ATTACK_POWER].GetValue();

            int skillStat = skillStatType switch
            {
                1 => attackerAttr[ATTR_EXPERTY1].GetValue(),
                2 => attackerAttr[ATTR_EXPERTY2].GetValue(),
                _ => 0
            };
            if (IsBypassDefense(attacker))
                defenseIgnore = 1;

            int targetDefense = _calcDefensePower(true, attackType, attacker, target, defenseIgnore);

            skillPercentDamage += attackerAttr[ATTR_ADD_SKILL_DAMAGE_RATIO].GetValue() / 100;

            int firstMinDamage = _calcFirstDamage(attackType, baseMinAttackPower, skillAttackPower, skillStat, skillPercentDamage);
            int firstMaxDamage = _calcFirstDamage(attackType, baseMaxAttackPower, skillAttackPower, skillStat, skillPercentDamage);

            var targetArmorType = target.GetArmorType();
            var meleeType = attacker.GetMeleeType();

            int bonusDamage = attackerAttr.GetBonusDamage(targetArmorType) - targetAttr.GetReduceDamage(attackType);

            float bonusPercentDamage = attackerAttr.GetBonusPercentDamage(targetArmorType) / 100f;

            float armorDamageRatio = _weaponArmorMap[meleeType][targetArmorType] /100 + bonusPercentDamage;

            int secondDamage = 0;

            var status = attacker.GetStatusManager().GetStatusFlag();
            int tmpDamage = firstMinDamage;
            if ((status.GetFlags() & (ulong) GeneralStatusFlags.ENABLE_GM_MAX_DAMAGE) != 0)
                tmpDamage = firstMaxDamage;

            float damamgeDecreaseRatio = 0.7f;

            if (target.IsObjectType(ObjectType.PLAYER_OBJECT) && attacker.IsObjectType(ObjectType.PLAYER_OBJECT))
                damamgeDecreaseRatio = 0.3f;//PVP

            secondDamage = _calcSecondDamage(attackType, tmpDamage, firstMaxDamage, bonusDamage,
                attacker.GetDisplayLevel(), target.GetDisplayLevel(), targetDefense, armorDamageRatio,
                damamgeDecreaseRatio);

            if (secondDamage <= firstMinDamage / 20)
            {
                var damageBound = firstMinDamage / 40 + 1;
                secondDamage = damageBound + GlobalRandom.Rand(0, damageBound);
            }

            return secondDamage;

        }

        private static int _calcSecondDamage(AttackType attackType, int firstMinDamage, int firstMaxDamage, int bonusDamage, ushort attackerLevel, ushort targetLevel, int targetDefense, float armorDamageRatio, float damamgeDecreaseRatio)
        {
            int firstDamage = GlobalRandom.Rand(firstMinDamage, firstMaxDamage);
            int secondDamage = 0;
            float ratio = 0;
            targetDefense = SunCalc.Min(0, targetDefense);

            ratio = (80 + targetLevel * 6 - targetDefense) /
                    (750 + targetLevel * 2) +
                    damamgeDecreaseRatio +
                    ((attackerLevel - targetLevel) * 0.03f);

            if (ratio < 0.1f) ratio = 0.1f;

            secondDamage = (int) (firstDamage * SunCalc.Max(1, ratio));
            secondDamage = (int) (secondDamage * armorDamageRatio);

            secondDamage += bonusDamage;

            return SunCalc.Min(0, secondDamage);
        }

        private static int _calcFirstDamage(AttackType attackType, int baseAttackPower, int skillAttackPower,
            int skillStat, float skillPercentDamage)
        {
            return SunCalc.Min(0, (int) ((baseAttackPower + skillAttackPower + skillStat) * (skillPercentDamage+1)));

        }
        private static int _calcDefensePower(bool bBase, AttackType attackType, Character attacker, Character target, float defenseIgnore)
        {
            if (defenseIgnore >= 1) return 0;
            int targetDefense = 0;
            

            var targetAttr = target.GetAttributes(); 
            var attackerAttr = attacker.GetAttributes();

            if (bBase)
            {
                if (attackType == ATTACK_TYPE_MELEE)
                {
                    targetDefense = targetAttr[ATTR_BASE_MELEE_DEFENSE_POWER].GetValue();
                    targetDefense += targetAttr[ATTR_OPTION_PHYSICAL_DEFENSE_POWER].GetValue();

                }
                else if (attackType == ATTACK_TYPE_RANGE)
                {
                    targetDefense = targetAttr[ATTR_BASE_RANGE_DEFENSE_POWER].GetValue();
                    targetDefense += targetAttr[ATTR_OPTION_PHYSICAL_DEFENSE_POWER].GetValue();
                }
                else
                {
                    targetDefense = targetAttr[ATTR_BASE_MAGICAL_DEFENSE_POWER].GetValue();
                    targetDefense += targetAttr[ATTR_OPTION_MAGICAL_DEFENSE_POWER].GetValue();
                }
            }
            else
            {
                targetDefense = targetAttr.GetMagicalDefense(attackType);
            }

            targetDefense += targetAttr.GetBonusDefense(attackType);

            int increaseDef = targetDefense * targetAttr[ATTR_ADD_DEFENSE_INC_RATIO].GetValue() / 100;
            int decreaseDef = 0;
            if (attacker != null)
            {
                decreaseDef = targetDefense * attackerAttr.GetReduceDefenseRate(attackType) / 100;
            }

            targetDefense = targetDefense + increaseDef - decreaseDef;

            if (targetDefense > 0)
                targetDefense -= (int)(targetDefense * defenseIgnore);

            return targetDefense;

        }

        private static int _calcAttackPower(bool bBase, AttackType attackType, bool min, Character attacker)
        {
            int baseAttackPower = 0;
            var attr = attacker.GetAttributes();
            if (bBase)
            {
                if (attackType == ATTACK_TYPE_MELEE)
                {
                    baseAttackPower = attr[ATTR_OPTION_PHYSICAL_ATTACK_POWER].GetValue();
                    if (min) baseAttackPower += attr[ATTR_BASE_MELEE_MIN_ATTACK_POWER].GetValue();
                    else baseAttackPower += attr[ATTR_BASE_MELEE_MAX_ATTACK_POWER].GetValue();
                }
                else if (attackType == ATTACK_TYPE_RANGE)
                {
                    baseAttackPower = attr[ATTR_OPTION_PHYSICAL_ATTACK_POWER].GetValue();
                    if (min) baseAttackPower += attr[ATTR_BASE_RANGE_MIN_ATTACK_POWER].GetValue();
                    else baseAttackPower += attr[ATTR_BASE_RANGE_MAX_ATTACK_POWER].GetValue();
                }
                else
                {
                    baseAttackPower = attr[ATTR_OPTION_MAGICAL_ATTACK_POWER].GetValue();
                    if (min) baseAttackPower += attr[ATTR_BASE_MAGICAL_MIN_ATTACK_POWER].GetValue();
                    else baseAttackPower += attr[ATTR_BASE_MAGICAL_MAX_ATTACK_POWER].GetValue();
                }
            }
            else
            {
                baseAttackPower = attr.GetMagicalAttackPower(attackType);
            }

            baseAttackPower += baseAttackPower * attr[ATTR_ADD_ATTACK_INC_RATIO].GetValue() / 100;

            return baseAttackPower;
        }


        private static bool IsPhysicalHit(Character attacker, Character target)
        {
            var attackerAttrs = attacker.GetAttributes();
            int phyAttackRate = attackerAttrs[ATTR_PHYSICAL_ATTACK_SUCCESS_RATIO].GetValue();
            if (phyAttackRate <= 0) phyAttackRate = 1;

            int diffLevel = attacker.GetDisplayLevel() - target.GetDisplayLevel();
            var weightLevel = 1 - diffLevel * 0.05f;

            int avoidValue = SunCalc.Max(9000, 10000 * target.GetPhysicalAvoidValue() / phyAttackRate); //[1]

            avoidValue = (int) (avoidValue * weightLevel);

            if (avoidValue < 500) avoidValue = 500;
            //else if(avoidValue > 9000) avoidValue = 9000; Moved To [1]

            return !GlobalRandom.IsSuccess(avoidValue);
        }

        private static bool IsCriticalHit(ObjectType objectType, int critRatio, ushort level)
        {
            if ((objectType & ObjectType.PLAYER_OBJECT) == ObjectType.PLAYER_OBJECT)
            {
                int blockFactor = 30 + level * 4;
                int blockRatio = GlobalRandom.Rand(1, blockFactor);

                if (blockRatio <= critRatio) return true;
            }
            else
            {
                return GlobalRandom.IsSuccess(critRatio * 100);
            }

            return false;
        }
        private static bool IsBypassDefense(Character attacker)
        {
            var ratio = attacker.GetAttributes()[ATTR_BYPASS_DEFENCE_RATIO].GetValue();
            return ratio != 0 && GlobalRandom.IsSuccess(ratio * 100);
        }

        public static int CalcNormalDamage(Character attacker, Character target, AttackType baseAttackType,
            AttackType magicAttackType, int critRatioBonus, ref byte effect, float defenseIgnore)
        {
            return _calcDamage(true, attacker, target, baseAttackType, magicAttackType, 0, 0, critRatioBonus,
                ref effect, 0, defenseIgnore, true);
        }

        public static int CalcSkillDamage(Character attacker, Character target, AttackType attackType,
            int skillAttackPower, float skillPercentDamage, int critRatioBonus, ref byte effect, byte skillStatType,
            bool canCrit)
        {
            var baseAttackType = ATTACK_TYPE_MAGIC;
            if (attackType is ATTACK_TYPE_MELEE or ATTACK_TYPE_RANGE)
                baseAttackType = attackType;
            return _calcDamage(false, attacker, target, baseAttackType, attackType, skillAttackPower,
                skillPercentDamage, critRatioBonus, ref effect, skillStatType, 0, canCrit);
        }

        public static int CalcIncreaseHeal(IncreaseHealAbilityType healType, int healValue, Character user)
        {
            var abilityInfo = GetAbilityInfo(user, CharStateType.kCharStateIncreaseHeal);
            if (abilityInfo == null) return 0;

            var tmpHealType = (IncreaseHealAbilityType) abilityInfo.option1;
            if(tmpHealType!= IncreaseHealAbilityType.SKILL_AND_ITEM)
                if (tmpHealType != healType)
                    return 0;

            int addValue = 0;
            int addHealValue = abilityInfo.Params[0];
            addValue += addHealValue;

            var addHealRatio = abilityInfo.Params[1];
            if (addHealRatio != 0)
                addValue +=(int) (healValue * (addHealRatio/1000f));

            return addValue;
        }

        public static BaseAbilityInfo? GetAbilityInfo(Character user, CharStateType type)
        {
            var statusManager = user.GetStatusManager();

            if (statusManager == null) return null;

            if(!statusManager.FindStatus(type,out var status)) return null;
            if (!status!.IsAbilityStatus()) return null;

            var abilityStatus = (AbilityStatus) status;

            return abilityStatus.BaseAbilityInfo;

        }

        public static int CalcIncreaseSkillDamage(Character character, SkillBase skill, int skillValue)
        {
            var statusManager = character.GetStatusManager();

            if (!statusManager.FindStatus(CharStateType.kCharStateIncreseSkillDamage, out AbilityStatus? status))
                return 0;

            var baseSkillInfo = skill.GetBaseSkillInfo();
            if (baseSkillInfo == null) return 0;

            if (!baseSkillInfo.TryGetAbilityInfo(AbilityID.kAbilityIncreseSkillDamage, out var baseAbilityInfo))
                return 0;

            int addDamage = 0;
            int addValue = baseAbilityInfo!.Params[0];
            addDamage += addValue;
            int addRatio = baseAbilityInfo.Params[1];
            if (addRatio != 0)
            {
                addDamage += (int)(skillValue * (addRatio/1000f));
            }

            return addDamage;
        }

        public static int CalcIncreaseCurse(SkillEnum skillClassCode, int skillValue, Character skillUser)
        {
            var abilityInfo = GetAbilityInfo(skillUser, CharStateType.CHAR_STATE_CURSE_INCREASE);
            if(abilityInfo==null) return 0;

            var addRatio = 0;

            switch (skillClassCode)
            {
                case SkillEnum.SKILL_PAIN:
                    addRatio = abilityInfo.option1;
                    break;
                case SkillEnum.SKILL_DARK_FIRE:
                    addRatio = abilityInfo.option2;
                    break;
                case SkillEnum.SKILL_ENCHANT_POISON:
                    addRatio = abilityInfo.Params[0];
                    break;
                default:
                    return 0;
            }

            if (skillValue == 0 || addRatio == 0) return 0;

            var addValue = (int)(skillValue * (addRatio / 1000f));

            return addValue;
        }
    }


}
