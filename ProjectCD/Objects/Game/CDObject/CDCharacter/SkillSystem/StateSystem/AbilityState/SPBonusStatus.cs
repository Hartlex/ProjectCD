using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class SpBonusStatus : AbilityStatus
    {
        public override void Start()
        {
            var owner = GetOwner();
            if (owner == null) return;

            int addValue = (int) AbilityValueType;
            if (addValue != 0)
            {
                SkillAttrCalc.AddAttribute(AttrType.ATTR_OPTION_PHYSICAL_ATTACK_POWER, AttrValueKind.VALUE_TYPE_VALUE, addValue);
            }

            int addRatio = AbilityValue;
            if (addRatio != 0)
            {
                SkillAttrCalc.AddAttribute(AttrType.ATTR_OPTION_PHYSICAL_ATTACK_POWER, AttrValueKind.VALUE_TYPE_PERCENT_PER_CUR, addRatio);
            }
        }

        public override void Execute() {}

        public override void End()
        {
            var owner = GetOwner();
            if (owner == null) return;

            int addValue = (int)AbilityValueType;
            if (addValue != 0)
            {
                SkillAttrCalc.DeleteAttribute(AttrType.ATTR_OPTION_PHYSICAL_ATTACK_POWER, AttrValueKind.VALUE_TYPE_VALUE, addValue);
            }

            int addRatio = AbilityValue;
            if (addRatio != 0)
            {
                SkillAttrCalc.DeleteAttribute(AttrType.ATTR_OPTION_PHYSICAL_ATTACK_POWER, AttrValueKind.VALUE_TYPE_PERCENT_PER_CUR, addRatio);
            }
        }
    }
}
