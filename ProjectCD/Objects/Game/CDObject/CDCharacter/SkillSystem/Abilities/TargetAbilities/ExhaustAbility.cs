using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities
{
    internal class ExhaustAbility : Ability
    {
        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            if (!base.Execute(target, out result)) return false;
            //target is not null

            SkillResultExhaust exResult = new SkillResultExhaust(result);
            var abilityInfo = GetBaseAbilityInfo();
            var valueType = (AttrValueKind) abilityInfo.Params[0];
            var value = abilityInfo.Params[1];

            if (GetAbilityID() == AbilityID.ABILITY_EXHAUST_HP)
            {
                if (valueType == AttrValueKind.VALUE_TYPE_PERCENT_PER_MAX)
                    value = target!.GetMaxHP() * value / 1000;
                else if (valueType == AttrValueKind.VALUE_TYPE_PERCENT_PER_CUR)
                    value = target!.GetHP() * value / 1000;

                if (value <= 0) value = 1;
                target!.SetHP(value);
            }
            else if (GetAbilityID() == AbilityID.ABILITY_EXHAUST_MP)
            {
                if (valueType == AttrValueKind.VALUE_TYPE_PERCENT_PER_MAX)
                    value = target!.GetMaxMP() * value / 1000;
                else if (valueType == AttrValueKind.VALUE_TYPE_PERCENT_PER_CUR)
                    value = target!.GetMP() * value / 1000;

                target!.SetMP(value);
            }

            exResult.TargetHP = (uint) target!.GetHP();
            exResult.TargetMP = (uint) target!.GetMP();

            result = exResult;

            return true;
        }
    }
}
