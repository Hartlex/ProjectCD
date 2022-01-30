using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class CurrentHPIncreaseAbility : BaseStatusAbility
    {
        public override bool IsValidState()
        {
            return GetAttrType() != AttrType.ATTR_TYPE_INVALID &&
                   GetCharStateType() != CharStateType.CHAR_STATE_INVALID;
        }


    }
}
