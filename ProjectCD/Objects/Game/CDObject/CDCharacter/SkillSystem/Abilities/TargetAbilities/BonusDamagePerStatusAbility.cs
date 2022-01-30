using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities
{
    internal class BonusDamagePerStatusAbility : Ability
    {
        public override bool CanExecute(Character attacker, Character target, uint mainTargetKey, SunVector mainTargetPos)
        {
            return false;
        }

    }
}
