using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.PassiveAbilities
{
    internal class PassiveStatusAbility : Ability
    {
        public override AbilityType GetAbilityType()
        {
            return AbilityType.ABILITY_TYPE_PASSIVE;
        }

        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            result = null;
            var attacker = GetAttacker();
            if (attacker == null) return false;

            var attrID = GetAttrType();
            if (attrID == AttrType.ATTR_TYPE_INVALID) return false;

            var abilityInfo = GetBaseAbilityInfo();
            var addValue = abilityInfo.Params[1];
            if (addValue == 0) return false;

            var attrCalc = new SkillAttrCalc(attacker.GetAttributes());
            attrCalc.AddAttribute(attrID, (AttrValueKind) abilityInfo.Params[0], addValue);

            return false;
        }

        public override void Release()
        {
            var attacker = GetAttacker();
            if (attacker == null) return;

            var attrID = GetAttrType();
            if (attrID == AttrType.ATTR_TYPE_INVALID) return;

            var abilityInfo = GetBaseAbilityInfo();
            var addValue = abilityInfo.Params[1];
            if (addValue == 0) return;

            var attrCalc = new SkillAttrCalc(attacker.GetAttributes());
            attrCalc.DeleteAttribute(attrID, (AttrValueKind)abilityInfo.Params[0], addValue);

            return;
        }
    }
}
