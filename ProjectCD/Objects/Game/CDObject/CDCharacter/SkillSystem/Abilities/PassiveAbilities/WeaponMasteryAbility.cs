using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.PassiveAbilities
{
    internal class WeaponMasteryAbility : Ability
    {
        public override void Release()
        {
            var attacker = GetAttacker();
            if (attacker == null) return;

            var calc = new SkillAttrCalc(attacker.GetAttributes());

            var abilityInfo = GetBaseAbilityInfo();
            int addAttackPower = abilityInfo.Params[0];
            if (addAttackPower != 0)
            {
                calc.DeleteAttribute(AttrType.ATTR_OPTION_PHYSICAL_ATTACK_POWER, AttrValueKind.VALUE_TYPE_VALUE, addAttackPower);
            }
            int addAttackSpeed = abilityInfo.Params[1];
            if (addAttackSpeed != 0)
            {
                calc.DeleteAttribute(AttrType.ATTR_OPTION_PHYSICAL_ATTACK_POWER, AttrValueKind.VALUE_TYPE_VALUE, addAttackSpeed);
            }

        }

        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            result = new EmptyResult();
            var attacker = GetAttacker();
            if (attacker == null) return false;

            var calc = new SkillAttrCalc(attacker.GetAttributes());

            var abilityInfo = GetBaseAbilityInfo();
            int addAttackPower = abilityInfo.Params[0];
            if (addAttackPower != 0)
            {
                calc.AddAttribute(AttrType.ATTR_OPTION_PHYSICAL_ATTACK_POWER, AttrValueKind.VALUE_TYPE_VALUE, addAttackPower);
            }
            int addAttackSpeed = abilityInfo.Params[1];
            if (addAttackSpeed != 0)
            {
                calc.AddAttribute(AttrType.ATTR_OPTION_PHYSICAL_ATTACK_POWER, AttrValueKind.VALUE_TYPE_VALUE, addAttackSpeed);
            }

            return false;
        }
    }
}
