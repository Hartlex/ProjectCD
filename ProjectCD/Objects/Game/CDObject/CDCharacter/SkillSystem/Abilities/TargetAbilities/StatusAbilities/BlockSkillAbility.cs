using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class BlockSkillAbility : BaseStatusAbility
    {
        public override bool IsValidState()
        {
            switch (GetCharStateType())
            {
                case CharStateType.CHAR_STATE_SEALING:
                case CharStateType.CHAR_STATE_CONFUSE:
                case CharStateType.CHAR_STATE_SLIP:
                    return true;
                
            }

            return false;
        }
    }
}
