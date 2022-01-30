﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class BonusDamageAbility :BaseStatusAbility
    {
        public override bool IsValidState()
        {
            return GetCharStateType() == CharStateType.CHAR_STATE_STAT_DAMAGE_ADD;
        }
    }
}
