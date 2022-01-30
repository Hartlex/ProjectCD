using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class MirrorAbility : BaseStatusAbility
    {
        public override bool IsValidState()
        {
            switch (GetCharStateType())
            {
                case CharStateType.CHAR_STATE_REFLECT_DAMAGE:
                case CharStateType.CHAR_STATE_REFLECT_FEAR:
                case CharStateType.CHAR_STATE_REFLECT_FROZEN:
                case CharStateType.CHAR_STATE_REFLECT_STUN:
                case CharStateType.CHAR_STATE_REFLECT_SLOW:
                case CharStateType.CHAR_STATE_REFLECT_SLOWDOWN:
                    return true;
            }

            return false;
        }
    }
}
