using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class LowHPAbility : BaseStatusAbility
    {
        public override bool IsValidState()
        {
            switch (GetCharStateType())
            {
                case CharStateType.CHAR_STATE_STAT_LOWHP_ATTACK_DECREASE:
                case CharStateType.CHAR_STATE_STAT_LOWHP_ATTACK_INCREASE:
                case CharStateType.CHAR_STATE_STAT_LOWHP_DEFENSE_DECREASE:
                case CharStateType.CHAR_STATE_STAT_LOWHP_DEFENSE_INCREASE:
                    return true;
            }

            return false;
        }
    }
}
