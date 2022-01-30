using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class BuffStatusAbility : BaseStatusAbility
    {
        public override bool IsValidState()
        {
            return GetAttrType() != AttrType.ATTR_TYPE_INVALID &&
                   GetCharStateType() != CharStateType.CHAR_STATE_INVALID;
        }
    }
}
