using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities
{
    internal class AbilityFactory : Singleton<AbilityFactory>
    {
        public Ability? AllocAbility(AbilityID abilityID, SkillType type)
        {
            switch (abilityID)
            {
                case AbilityID.ABILITY_INVALID:
                case AbilityID.ABILITY_DAMAGE:
                    return new DamageAbility();
                case AbilityID.ABILITY_DAMAGE_PER_TIME:
                    return new PeriodicDamageAbility();
                case AbilityID.ABILITY_CUR_HP_INCREASE:
                    return new CurrentHPIncreaseAbility();
                case AbilityID.ABILITY_KNOCKBACK:
                    return new ThrustAbility();
                case AbilityID.ABILITY_KNOCKBACK2:
                    return new ThrustAbility();
                case AbilityID.ABILITY_SELF_DESTRUCTION:
                    return new ThrustAbility();
                case AbilityID.ABILITY_EXHAUST_HP:
                    return new ExhaustAbility();
                case AbilityID.ABILITY_EXHAUST_MP:
                    return new ExhaustAbility();
                case AbilityID.ABILITY_AGGROPOINT_INCREASE:
                    return new AggroAbility();
                case AbilityID.ABILITY_TELEPORT:
                    return new TeleportAbility();
                case AbilityID.ABILITY_RESURRECTION:
                    return new ResurrectionAbility();

                default:
                    return new Ability();
            }
        } 
    }
}
