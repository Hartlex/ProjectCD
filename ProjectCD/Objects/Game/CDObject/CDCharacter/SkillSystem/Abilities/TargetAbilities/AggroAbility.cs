using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using static SunStructs.Definitions.AbilityID;
using static SunStructs.Definitions.AIStateID;
using static SunStructs.Definitions.BattlePointType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities
{
    internal class AggroAbility : Ability
    {
        public override bool IsValidState()
        {
            return GetCharStateType() == CharStateType.kCharStateIncreaseAggroPoint;
        }

        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            if (!base.Execute(target, out result)) return false;

            var attacker = GetAttacker();
            if (attacker == null) return false;

            var abilityInfo = GetBaseAbilityInfo();

            if (GetAbilityID() == ABILITY_AGGROPOINT_INCREASE)
                target!.AddBattlePoint(attacker, BATTLE_POINT_ETC, abilityInfo.Params[1]);
            else if(GetAbilityID() == ABILITY_TARGET_CHANGE)
                if (GlobalRandom.IsSuccess(abilityInfo.Params[1] / 10))
                {
                    target!.SetTargetChar(attacker);
                    target.ChangeState(STATE_ID_TRACK);
                }

            return true;
        }
    }
}
