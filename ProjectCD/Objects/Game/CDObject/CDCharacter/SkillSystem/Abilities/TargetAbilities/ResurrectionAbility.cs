using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities
{
    internal class ResurrectionAbility : Ability
    {
        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            result = new EmptyResult();
            var attacker = GetAttacker();
            if (attacker == null) return false;
            if (ReferenceEquals(attacker, target) && attacker.IsObjectType(ObjectType.PLAYER_OBJECT) == false)
                return false;

            var abilityInfo = GetBaseAbilityInfo();
            var recoverExp = abilityInfo.option2 / 1000f;
            var recoverHp = abilityInfo.Params[0] / 1000f;
            var recoverMp = abilityInfo.Params[1] / 1000f;

            return target!.OnResurrection(recoverExp, recoverHp, recoverMp, attacker as Player);
        }
    }
}
