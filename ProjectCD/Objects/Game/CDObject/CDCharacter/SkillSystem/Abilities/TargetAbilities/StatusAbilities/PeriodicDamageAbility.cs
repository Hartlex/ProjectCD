using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class PeriodicDamageAbility : BaseStatusAbility
    {
        public override bool IsValidState()
        {
            switch (GetCharStateType())
            {
                case CharStateType.CHAR_STATE_POISON:
                case CharStateType.CHAR_STATE_FIRE_WOUND:
                case CharStateType.CHAR_STATE_WOUND:
                case CharStateType.CHAR_STATE_PAIN:
                case CharStateType.CHAR_STATE_FIRE_WOUND2:
                case CharStateType.CHAR_STATE_PAIN2:
                case CharStateType.kCharStatePoison3:
                case CharStateType.CHAR_STATE_PERIODIC_DAMAGE:
                case CharStateType.CHAR_STATE_PHOENIX_BURN:
                case CharStateType.CHAR_STATE_ELECTRICSHOCK:
                    return true;
            }

            return false;
        }
    }
}
