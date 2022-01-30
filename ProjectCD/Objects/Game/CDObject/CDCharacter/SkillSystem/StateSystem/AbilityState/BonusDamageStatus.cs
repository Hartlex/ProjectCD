using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General.Skill;
using static SunStructs.Definitions.AttackType;
using static SunStructs.Definitions.AttrValueKind;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    public class BonusDamageStatus :AbilityStatus
    {
        private AttackType _attackType;
        public override void Init(Character owner, Character? attacker, Ability ability)
        {
            base.Init(owner, attacker, ability);
            BaseAbilityInfo abilityInfo = ability.GetBaseAbilityInfo();
            _attackType = (AttackType) abilityInfo.option1;
        }

        public void AddDamage(AttackType attackType, ref int damage)
        {
            if (_attackType != ATTACK_TYPE_ALL_OPTION)
            {
                if (_attackType == ATTACK_TYPE_PHYSICAL_OPTION)
                {
                    if (attackType != ATTACK_TYPE_MELEE && attackType != ATTACK_TYPE_RANGE)
                        return;
                }
                else if (_attackType == ATTACK_TYPE_MAGIC_OPTION)
                {
                    if (attackType == ATTACK_TYPE_MELEE || attackType == ATTACK_TYPE_RANGE)
                        return;
                }
                else
                {
                    if (_attackType != attackType)
                        return;
                }
            }

            var calcValue = AbilityValue;
            if (AbilityValueType == VALUE_TYPE_PERCENT_PER_MAX) calcValue = damage * calcValue / 1000;
            else if(AbilityValueType == VALUE_TYPE_PERCENT_PER_CUR) calcValue = damage * calcValue / 1000;
            damage += calcValue;
        }

    }
}
