using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class ChangeAttrStatus : AbilityStatus
    {
        public override void Init(Character owner, Character? attacker, Ability ability)
        {
            base.Init(owner, attacker, ability);
            AbilityValueType = AttrValueKind.VALUE_TYPE_VALUE;
        }

        public override void End()
        {
            base.End();

            if (GetStateType() != CharStateType.CHAR_STATE_INVALID && BaseAbilityInfo.Params[2] != 0)
            {
                SendStatusDelBRD();
            }

            if (AttrType != AttrType.ATTR_TYPE_INVALID && IsApply)
            {
                var owner = GetOwner();
                if (owner != null)
                {
                    SkillAttrCalc.DeleteAttribute(AttrType, AbilityValueType, SumValue);
                }
            }
        }
    }
}
