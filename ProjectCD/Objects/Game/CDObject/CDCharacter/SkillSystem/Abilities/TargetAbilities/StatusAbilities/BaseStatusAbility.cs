using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class BaseStatusAbility : Ability
    {
        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            if (!base.Execute(target, out result)) return false;
            if (!IsValidState()) return false;
            var attacker = GetAttacker();
            if(attacker == null) return false;

            var abilityStatus = target!.GetStatusManager().AllocAbilityStatus(attacker, this);
            if (abilityStatus == null) return false;

            result!.AbilityCode = (ushort) abilityStatus.GetStateType();
            result.AbilityDuration = (uint) abilityStatus.GetApplicationTime();

            return true;
        }
    }
}
