using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.NonTargetAbilities;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.PassiveAbilities;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Effects;
using SunStructs.Definitions;
using static SunStructs.Definitions.AbilityID;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities
{
    internal class AbilityFactory : Singleton<AbilityFactory>
    {
        public Ability? AllocAbility(AbilityID abilityID, SkillType type)
        {
            switch (abilityID)
            {
                case ABILITY_INVALID:
                    return null;
                case ABILITY_DAMAGE:
                    return new DamageAbility();
                case ABILITY_DAMAGE_PER_TIME:
                    return new PeriodicDamageAbility();
                case ABILITY_CUR_HP_INCREASE:
                    return new CurrentHPIncreaseAbility();
                case ABILITY_KNOCKBACK:
                    return new ThrustAbility();
                case ABILITY_KNOCKBACK2:
                    return new ThrustAbility();
                case ABILITY_SELF_DESTRUCTION:
                    return new ThrustAbility();
                case ABILITY_EXHAUST_HP:
                    return new ExhaustAbility();
                case ABILITY_EXHAUST_MP:
                    return new ExhaustAbility();
                case ABILITY_AGGROPOINT_INCREASE:
                    return new AggroAbility();
                case ABILITY_FIGHTING_ENERGY_NUM_INCREASE:
                    Logger.Instance.Log($"Unknown Ability[ABILITY_FIGHTING_ENERGY_NUM_INCREASE]");
                    return new Ability();
                case ABILITY_BONUS_DAMAGE_PER_FIGHTING_ENERGY:
                    Logger.Instance.Log($"Unknown Ability[ABILITY_BONUS_DAMAGE_PER_FIGHTING_ENERGY]");
                    return new Ability();
                case ABILITY_TELEPORT:
                    return new TeleportAbility();
                case ABILITY_RESURRECTION:
                    return new ResurrectionAbility();
                case ABILITY_BUFF_RANGE_DAMAGE:
                    return new PeriodicEffectAbility();
                case ABILITY_AURORA:
                    return new AuroraAbility();
                case ABILITY_BONUS_DAMAGE_PER_SP:
                    Logger.Instance.Log($"Unknown Ability[ABILITY_BONUS_DAMAGE_PER_SP]");
                    return new Ability();
                case ABILITY_BONUS_DAMAGE_PER_STATUS:
                    Logger.Instance.Log($"Unknown Ability[ABILITY_BONUS_DAMAGE_PER_STATUS]");
                    return new Ability();
                case ABILITY_WEAPON_MASTERY:
                    return new WeaponMasteryAbility();
                case ABILITY_MONSTER_TRANSFORMATION:
                    Logger.Instance.Log($"Unknown Ability[eABILITY_MONSTER_TRANSFORMATION]");
                    return new Ability();
                case ABILITY_WIND_SHIELD:
                    return new WindShieldAbility();
                case ABILITY_STUN_STATUS:
                    return new StunAbility();
                case ABILITY_DRAGON_TRANSFORMATION1:
                    return new DragonTransformAbility();
                case ABILITY_SUMMON:
                    Logger.Instance.Log($"Unknown Ability[ABILITY_SUMMON]");
                    return new Ability();
                case ABILITY_RANDOM_AREA_ATTACK:
                    Logger.Instance.Log($"Unknown Ability[ABILITY_RANDOM_AREA_ATTACK]");
                    return new Ability();
                case ABILITY_ATTACK_DAMAGE_HP_ABSORPTION:
                    return new AbsorbAbility();
                case ABILITY_ATTACK_DAMAGE_MP_ABSORPTION:
                    return new AbsorbAbility();
                case ABILITY_ATTACKED_DAMAGE_HP_ABSORPTION:
                    return new AbsorbAbility();
                case ABILITY_ATTACKED_DAMAGE_MP_ABSORPTION:
                    return new AbsorbAbility();
                case ABILITY_SUMMON_TO_DIE:
                    Logger.Instance.Log($"Unknown Ability[ABILITY_SUMMON_TO_DIE]");
                    return new Ability();
                case ABILITY_ABNORMAL_STATUS:
                    return new AbnormalAbility();
                case ABILITY_FEAR:
                    return new AbnormalAbility();
                case ABILITY_REFLECT_DAMAGE:
                    return new MirrorAbility();
                case ABILITY_REFLECT_STUN:
                    return new MirrorAbility();
                case ABILITY_REFLECT_FEAR:
                    return new MirrorAbility();
                case ABILITY_REFLECT_FROZEN:
                    return new MirrorAbility();
                case ABILITY_REFLECT_SLOW:
                    return new MirrorAbility();
                case ABILITY_REFLECT_SLOWDOWN:
                    return new MirrorAbility();
                case ABILITY_MAGIC_SHIELD:
                    return new MagicShieldAbility();
                case ABILITY_LOWHP_ATTACKPOWER_CHANGE:
                    return new LowHPAbility();
                case ABILITY_LOWHP_DEFENSE_CHANGE:
                    return new LowHPAbility();
                case ABILITY_STATUS_HEAL:
                    return new CureAbility();
                case ABILITY_BONUS_DAMAGE_PER_ATTACK:
                    return new BonusDamageAbility();
                case ABILITY_PIERCE_ARROW:
                    return new InformationAbility();
                case ABILITY_SUMMON_CHANGE_STATUS:
                    return new InformationAbility();
                case ABILITY_DRAGON_TRANSFORMATION2:
                    return new InformationAbility();
                case ABILITY_DRAGON_TRANSFORMATION3:
                    return new InformationAbility();
                case ABILITY_SUMMON_DEAD_MONSTER:
                    Logger.Instance.Log($"Unknown Ability[ABILITY_SUMMON_DEAD_MONSTER]");
                    return new Ability();
                case ABILITY_BLOCK_SKILL:
                    return new BlockSkillAbility();
                case ABILITY_SUCTION_HPMP:
                    return new SuctionAbility();
                case ABILITY_CHANGE_ATTR:
                    return new ChangeAttrAbility();
                case ABILITY_CANCEL_STATUS:
                    return new CancelStatusAbility();
                case ABILITY_VITAL_SUCTION:
                    return new VitalSuctionAbility();
                case ABILITY_HIDE:
                    return new TransparentAbility();
                case ABILITY_DARK_BREAK:
                    Logger.Instance.Log($"Unknown Ability[ABILITY_DARK_BREAK]");
                    return new Ability();
                case ABILITY_SUMMON_CRYSTALWARP:
                    Logger.Instance.Log($"Unknown Ability[ABILITY_SUMMON_CRYSTALWARP]");
                    return new Ability();
                case ABILITY_SUMMON_CRYSTALWARP_DESTROY:
                    Logger.Instance.Log($"Unknown Ability[ABILITY_SUMMON_CRYSTALWARP_DESTROY]");
                    return new Ability();
                case ABILITY_PULLING:
                    return new ThrustAbility();
                case ABILITY_ROLLING_BOMB:
                case ABILITY_QUICKSTEP:
                    Logger.Instance.Log($"Unknown Ability[ABILITY_QUICKSTEP]");
                    return new Ability();
                case ABILITY_MAX_HP_INCREASE:
                case ABILITY_RECOVER_HP_INCREASE:
                case ABILITY_MAX_MP_INCREASE:
                case ABILITY_CUR_MP_INCREASE:
                case ABILITY_RECOVER_MP_INCREASE:
                case ABILITY_PHYSICAL_ATTACKPOWER_INCREASE:
                case ABILITY_MAGIC_ATTACKPOWER_INCREASE:
                case ABILITY_PHYSICAL_DEFENSE_INCREASE:
                case ABILITY_STAT_INCREASE:
                case ABILITY_PHYSICAL_ATTACKRATE_INCREASE:
                case ABILITY_PHYSICAL_AVOIDRATE_INCREASE:
                case ABILITY_MOVE_SPEED_INCREASE:
                case ABILITY_PHYSICAL_SPEED_INCREASE:
                case ABILITY_CASTING_TIME_INCREASE:
                case ABILITY_SKILLRANGE_INCREASE:
                case ABILITY_CRITICAL_RATIO_CHANGE:
                case ABILITY_CRITICAL_DAMAGE_CHANGE:
                case ABILITY_SKILLDAMAGE_INCREASE:
                case ABILITY_SKILL_COOL_TIME_INCREASE:
                case ABILITY_MP_SPEND_INCREASE:
                case ABILITY_ADRENALINE:
                case ABILITY_ATTR_DEFENSIVE_POWER:
                case ABILITY_INCREASE_SKILL_ABILITY:
                case ABILITY_ENCHANT_POISON:
                case ABILITY_MAX_SD_INCREASE:
                case ABILITY_CUR_SD_INCREASE:
                case kAbilityIncreseHeal:
                case kAbilityActiveComboSkill:
                case kAbilityActiveIncreseSkillDamage:
                case ABILITY_ATTR_ATTACK_POWER:
                case ABILITY_DETECTING_HIDE:
                case ABILITY_SKILL_STATE_IGNORE:
                    if (type == SkillType.SKILL_TYPE_PASSIVE)
                        return new PassiveStatusAbility();
                    return new BuffStatusAbility();

                default:
                    Logger.Instance.Log($"Unknown Ability[{abilityID}]");
                    return new Ability();
            }
        } 
    }
}
