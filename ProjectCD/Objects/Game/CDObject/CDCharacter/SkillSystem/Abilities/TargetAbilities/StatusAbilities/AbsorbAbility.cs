using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class AbsorbAbility : BaseStatusAbility
    {
        public override bool IsValidState()
        {
            switch (GetCharStateType())
            {
                case CharStateType.CHAR_STATE_ABSORB:
                case CharStateType.CHAR_STATE_IMMUNITY_DAMAGE:
                    return true;
            }

            return false;
        }
    }
}
