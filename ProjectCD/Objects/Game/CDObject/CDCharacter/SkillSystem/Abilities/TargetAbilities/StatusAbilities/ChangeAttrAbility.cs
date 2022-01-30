using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class ChangeAttrAbility : BaseStatusAbility
    {
        public override bool IsValidState()
        {
            return GetCharStateType() == CharStateType.CHAR_STATE_CHANGE_ATTR;
        }

        public override bool CanExecute(Character attacker, Character target, uint mainTargetKey, SunVector mainTargetPos)
        {
            if (!base.CanExecute(attacker, target, mainTargetKey, mainTargetPos)) return false;

            var baseInfo = GetBaseAbilityInfo();
            var targetState = baseInfo.option2;

            if (baseInfo.RangeType == AbilityRangeType.SKILL_ABILITY_ME)
            {
                if (targetState != 0) return false;
            }
            else if (baseInfo.RangeType != AbilityRangeType.SKILL_ABILITY_ENEMY)  return false;

            var attackerState = baseInfo.option1;
            if (attackerState != 0)
            {
                if (!attacker.GetStatusManager().FindStatus((CharStateType) attackerState)) return false;
            }

            if (targetState != 0)
            {
                if (!target.GetStatusManager().FindStatus((CharStateType) targetState)) return false;
            }

            return true;
        }

        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            result = null;
            if (!IsValidState()) return false;

            var attacker = GetAttacker();
            if(attacker==null) return false;

            var abilityStatus = attacker.GetStatusManager().AllocAbilityStatus(attacker, this);
            if (abilityStatus == null) return false;

            if (GetBaseAbilityInfo().Params[0] == 73)
            {
                result = new EmptyResult();
            }
            else
            {
                if (!base.Execute(target, out result)) return false;
                result!.AbilityCode = (ushort) abilityStatus.AttrType;
                result!.AbilityDuration = (uint) abilityStatus.GetApplicationTime();
            }

            return true;
        }
    }
}
