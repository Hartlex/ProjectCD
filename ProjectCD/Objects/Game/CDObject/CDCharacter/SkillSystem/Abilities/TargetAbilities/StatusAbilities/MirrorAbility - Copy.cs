using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class WindShieldAbility : BaseStatusAbility
    {
        public override bool IsValidState()
        {
            switch (GetCharStateType())
            {
                case CharStateType.CHAR_STATE_BUF_RANGE_DAMAGE:
                case CharStateType.CHAR_STATE_BUF_RANGE_DAMAGE2:
                case CharStateType.CHAR_STATE_BUF_RANGE_DAMAGE3:
                case CharStateType.CHAR_STATE_BUF_RANGE_DAMAGE4:

                    return true;
            }

            return false;
        }
    }
}
